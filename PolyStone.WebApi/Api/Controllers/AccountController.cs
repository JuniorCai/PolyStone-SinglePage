using System;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.UI;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using PolyStone.Api.Models;
using PolyStone.Authorization;
using PolyStone.Authorization.Users;
using PolyStone.MultiTenancy;
using PolyStone.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace PolyStone.Api.Controllers
{
    public class AccountController : AbpApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly LogInManager _logInManager;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public AccountController(LogInManager logInManager)
        {
            _logInManager = logInManager;
            LocalizationSourceName = PolyStoneConsts.LocalizationSourceName;
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

                var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());

                var currentUtc = new SystemClock().UtcNow;
                ticket.Properties.IssuedUtc = currentUtc;
                ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

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

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Invalid request!");
            }
        }
    }
}
