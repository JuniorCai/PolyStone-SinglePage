using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Timing;
using Abp.Zero.Configuration;
using Microsoft.AspNet.Identity;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.MultiTenancy;

namespace PolyStone.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private readonly UserManager _userManager;

        public LogInManager(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig, IIocResolver iocResolver,
            RoleManager roleManager)
            : base(
                  userManager,
                  multiTenancyConfig,
                  tenantRepository,
                  unitOfWorkManager,
                  settingManager,
                  userLoginAttemptRepository,
                  userManagementConfig,
                  iocResolver,
                  roleManager)
        {
            _userManager = userManager;
        }


        [UnitOfWork]
        public virtual async Task<AbpLoginResult<Tenant, User>> LoginByPhoneAsync(string phoneNum, string plainPassword, string tenancyName = null, bool shouldLockout = true)
        {
            var result = await LoginByPhoneAsyncInternal(phoneNum, plainPassword, tenancyName, shouldLockout);
            await SaveLoginAttempt(result, tenancyName, phoneNum);
            return result;
        }

        protected virtual async Task<AbpLoginResult<Tenant, User>> LoginByPhoneAsyncInternal(string phoneNum, string plainPassword, string tenancyName, bool shouldLockout)
        {
            if (phoneNum.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(phoneNum));
            }

            if (plainPassword.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(plainPassword));
            }

            //Get and check tenant
            Tenant tenant = null;
            using (UnitOfWorkManager.Current.SetTenantId(null))
            {
                if (!MultiTenancyConfig.IsEnabled)
                {
                    tenant = await GetDefaultTenantAsync();
                }
                else if (!string.IsNullOrWhiteSpace(tenancyName))
                {
                    tenant = await TenantRepository.FirstOrDefaultAsync(t => t.TenancyName == tenancyName);
                    if (tenant == null)
                    {
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidTenancyName);
                    }

                    if (!tenant.IsActive)
                    {
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.TenantIsNotActive, tenant);
                    }
                }
            }

            var tenantId = tenant == null ? (int?)null : tenant.Id;
            using (UnitOfWorkManager.Current.SetTenantId(tenantId))
            {
                //TryLoginFromExternalAuthenticationSources method may create the user, that's why we are calling it before AbpStore.FindByNameOrEmailAsync
                var loggedInFromExternalSource = false;

                var user = await _userManager.FindByPhoneAsync(phoneNum);
                if (user == null)
                {
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidUserNameOrEmailAddress, tenant);
                }

                if (await UserManager.IsLockedOutAsync(user.Id))
                {
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                }

                if (!loggedInFromExternalSource)
                {
                    UserManager.InitializeLockoutSettings(tenantId);
                    var verificationResult = UserManager.PasswordHasher.VerifyHashedPassword(user.Password, plainPassword);
                    if (verificationResult == PasswordVerificationResult.Failed)
                    {
                        return await GetFailedPasswordValidationAsLoginResultAsync(user, tenant, shouldLockout);
                    }

                    if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        return await GetSuccessRehashNeededAsLoginResultAsync(user, tenant);
                    }

                    await UserManager.ResetAccessFailedCountAsync(user.Id);
                }

                return await CreateLoginByPhoneResultAsync(user, tenant);
            }

    }
        protected virtual async Task<AbpLoginResult<Tenant, User>> CreateLoginByPhoneResultAsync(User user, Tenant tenant = null)
        {
            if (!user.IsActive)
            {
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserIsNotActive);
            }

            if (!user.IsPhoneNumberConfirmed)
            {
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserPhoneNumberIsNotConfirmed);
            }

            user.LastLoginTime = Clock.Now;

            await UserManager.AbpStore.UpdateAsync(user);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return new AbpLoginResult<Tenant, User>(
                tenant,
                user,
                await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
            );
        }


    }
}
