using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Abp.WebApi.Authorization;
using Abp.WebApi.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PolyStone.Api.Models;
using PolyStone.Authorization;
using PolyStone.Authorization.Users;
using PolyStone.MultiTenancy;
using PolyStone.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PolyStone.Authorization.Roles;
using PolyStone.CustomDomain.UserVerifies;
using PolyStone.UserVerifies;
using PolyStone.UserVerifies.Dtos;

namespace PolyStone.Api.Controllers
{
    public class AccountController : PolyStoneApiControllerBase
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly LogInManager _logInManager;
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly ITenantCache _tenantCache;
        private readonly IUserVerifyAppService _userVerifyAppService;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }


        public AccountController(LogInManager logInManager,UserManager userManager, IUserAppService userAppService, RoleManager roleManager, ITenantCache tenantCache,IUserVerifyAppService userVerifyAppService)
        {
            _logInManager = logInManager;
            LocalizationSourceName = PolyStoneConsts.LocalizationSourceName;
            _userAppService = userAppService;
            _roleManager = roleManager;
            _userManager = userManager;
            _tenantCache = tenantCache;
            _userVerifyAppService = userVerifyAppService;
        }

        [HttpPost]
        public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        {
            CheckModelState();

            try
            {
                var loginResult = await GetLoginResultAsync(
                    loginModel.Phone,
                    loginModel.Password,
                    loginModel.TenancyName
                );

                var ticket = GetTicketByLoginResult(loginResult);

                return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
            }
            catch (UserFriendlyException e)
            {
                ErrorInfo error=new ErrorInfo(){Code = e.Code,Details = e.Details,Message = e.Details};
                return new AjaxResponse(error);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string phone, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginByPhoneAsync(phone, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, phone, tenancyName);
            }
        }

        /// <summary>
        /// 异常编号1开头为用户登录异常错误，当为100000时，表示用户登录错误未不明确
        /// </summary>
        /// <param name="result"></param>
        /// <param name="usernameOrEmailAddress"></param>
        /// <param name="tenancyName"></param>
        /// <returns></returns>
        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(100001,L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(100002,L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(100003,L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(100004,L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(100005,L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                case AbpLoginResultType.UserPhoneNumberIsNotConfirmed:
                    return new UserFriendlyException(100006, L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(100000,L("LoginFailed"));
            }
        }


        [AbpApiAuthorize()]
        public async Task<AjaxResponse> GetCurrentUserInfo()
        {
            if (AbpSession.UserId == null || AbpSession.UserId.Value == 0)
            {
                ErrorInfo error = new ErrorInfo() { Code = 100007};
                return new AjaxResponse(error);
            }

            long userId = AbpSession.UserId.Value;
            var userDto = await _userAppService.Get(new EntityDto<long> {Id = userId});
            return new AjaxResponse(userDto);
        }

//        [AbpApiAuthorize()]
//        public async Task<AjaxResponse> ResetPassword(ResetModel model)
//        {
//            if (AbpSession.UserId == null || AbpSession.UserId.Value == 0)
//            {
//                ErrorInfo error = new ErrorInfo() { Code = 100007 };
//                return new AjaxResponse(error);
//            }
//
//            var userAuthCodeVerify = _userVerifyAppService.GetPagedUserVerifysAsync(
//                new GetUserVerifyInput()
//                {
//                    AuthCode = model.AuthCode,
//                    PhoneNumber = model.PhoneNumber,
//                    VerifyStatus = CodeVerifyStatus.Success
//                }).Result;
//            if (userAuthCodeVerify.TotalCount == 1)
//            {
//                
//            }
//
//            long userId = AbpSession.UserId.Value;
//            var userDto = await _userAppService.Get(new EntityDto<long> { Id = userId });
//            return new AjaxResponse(userDto);
//        }


        private AuthenticationTicket GetTicketByLoginResult(AbpLoginResult<Tenant, User> loginResult)
        {
            var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());

            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
            return ticket;
        }

        public async Task<AjaxResponse> Register(RegisterModel model)
        {
            try
            {
                CheckModelState();

                //Create user
                var user = new User
                {
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password,
                    IsActive = true,
                    EmailAddress = "",
                    Surname = "",
                    Name = ""
                };
                var authedCodeModel = _userVerifyAppService.GetPagedUserVerifysAsync(new GetUserVerifyInput()
                {
                    AuthCode = model.AuthCode,
                    PhoneNumber = model.PhoneNumber,
                    VerifyStatus = CodeVerifyStatus.Success
                });
                if (authedCodeModel != null)
                {
                    user.IsPhoneNumberConfirmed = true;
                }
                else
                {
                    return new AjaxResponse(false);
                }

                //Get external login info if possible
                ExternalLoginInfo externalLoginInfo = null;
                if (model.IsExternalLogin)
                {
                    //第三方注册写这里
                }
                else
                {
                    //Username and Password are required if not external login
                    if (model.UserName.IsNullOrEmpty() || model.Password.IsNullOrEmpty())
                    {
                        throw new UserFriendlyException(L("FormIsNotValidMessage"));
                    }
                }

                user.UserName = model.UserName;
                user.Password = new PasswordHasher().HashPassword(model.Password);

                //Switch to the tenant
                UnitOfWorkManager.Current.EnableFilter(AbpDataFilters.MayHaveTenant); //TODO: Needed?
                UnitOfWorkManager.Current.SetTenantId(AbpSession.GetTenantId());

                //Add default roles
                user.Roles = new List<UserRole>();
                foreach (var defaultRole in  _roleManager.Roles.Where(r => r.IsDefault).ToList())
                {
                    user.Roles.Add(new UserRole { RoleId = defaultRole.Id });
                }

                //Save user
                CheckErrors(await _userManager.CreateAsync(user));
                await UnitOfWorkManager.Current.SaveChangesAsync();

                //Directly login if possible
                if (user.IsActive)
                {
                    AbpLoginResult<Tenant, User> loginResult;
                    if (externalLoginInfo != null)
                    {
                        //第三方登录
                        loginResult = null;
                    }
                    else
                    {
                        loginResult = await GetLoginResultAsync(user.PhoneNumber, model.Password, GetTenancyNameOrNull());
                    }

                    if (loginResult.Result == AbpLoginResultType.Success)
                    {
                        var ticket = GetTicketByLoginResult(loginResult);

                        return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
                    }

                    Logger.Warn("New registered user could not be login. This should not be normally. login result: " + loginResult.Result);
                }

                //If can not login, show a register result page
                return new AjaxResponse(false);
            }
            catch (UserFriendlyException e)
            {
                ErrorInfo error = new ErrorInfo() { Code = e.Code, Details = e.Details, Message = e.Details };
                return new AjaxResponse(error);
            }
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

    }
}
