using System;
using System.Configuration;
using Abp.Owin;
using PolyStone.Api.Controllers;
using PolyStone.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PolyStone.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace PolyStone.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            #region 配置OAuth

            //第一步：配置跨域访问
            app.UseCors(CorsOptions.AllowAll);

            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            //第二步：使用OAuth密码认证模式
            app.UseOAuthAuthorizationServer(OAuthOptions.CreateServerOptions());

            #endregion

            app.UseAbp();

            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                // evaluate for Persistent cookies (IsPermanent == true). Defaults to 14 days when not set.
                ExpireTimeSpan = new TimeSpan(int.Parse(ConfigurationManager.AppSettings["AuthSession.ExpireTimeInDays.WhenPersistent"] ?? "14"), 0, 0, 0),
                SlidingExpiration = bool.Parse(ConfigurationManager.AppSettings["AuthSession.SlidingExpirationEnabled"] ?? bool.FalseString)
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();


        }
    }
}
