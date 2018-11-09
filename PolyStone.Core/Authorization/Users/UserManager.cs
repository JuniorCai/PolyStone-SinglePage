using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Microsoft.AspNet.Identity;
using PolyStone.Authorization.Roles;

namespace PolyStone.Authorization.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        private readonly UserStore _userStore;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            ISettingManager settingManager,
            IdentityEmailMessageService emailService,
            IUserTokenProviderAccessor userTokenProviderAccessor)
            : base(
                  userStore,
                  roleManager,
                  permissionManager,
                  unitOfWorkManager,
                  cacheManager,
                  organizationUnitRepository,
                  userOrganizationUnitRepository,
                  organizationUnitSettings,
                  localizationManager,
                  emailService,
                  settingManager,
                  userTokenProviderAccessor)
        {
            _userStore = userStore;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public virtual async Task<User> FindByPhoneAsync(string phoneNumber)
        {
            return await _userStore.FindByPhoneAsync(phoneNumber);
        }

        public override async Task<IdentityResult> CreateAsync(User user)
        {
            var result = await CheckDuplicatePhoneNumberAsync(user.Id, user.UserName, user.PhoneNumber);
            if (!result.Succeeded)
            {
                return result;
            }

            try
            {
                return await base.CreateAsync(user);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public virtual async Task<IdentityResult> CheckDuplicatePhoneNumberAsync(long? expectedUserId, string userName, string phoneNumber)
        {
            var user = (await FindByPhoneAsync(phoneNumber));
            if (user != null && user.Id != expectedUserId)
            {
                return AbpIdentityResult.Failed(string.Format(L("Identity.DuplicatePhoneNumber"), phoneNumber));
            }

            return IdentityResult.Success;
        }


        public override async Task<IdentityResult> CheckDuplicateUsernameOrEmailAddressAsync(long? expectedUserId, string userName, string emailAddress)
        {
            var user = (await FindByNameAsync(userName));
            if (user != null && user.Id != expectedUserId)
            {
                return AbpIdentityResult.Failed(string.Format(L("Identity.DuplicateUserName"), userName));
            }

            if (!emailAddress.IsNullOrEmpty())
            {
                user = (await FindByEmailAsync(emailAddress));
                if (user != null && user.Id != expectedUserId)
                {
                    return AbpIdentityResult.Failed(string.Format(L("Identity.DuplicateEmail"), emailAddress));
                }
            }

            return IdentityResult.Success;
        }
    }
}