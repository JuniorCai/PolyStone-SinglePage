using System.Linq;
using Abp.Authorization;
using Abp.Localization;

namespace PolyStone.CustomDomain.UserAuthorizations.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UserAuthorizationAppPermissions"/> for all permission names.
    /// </summary>
    public class UserAuthorizationAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了UserAuthorization 的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));



           

            var userAuthorization = entityNameModel.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization , L("UserAuthorization"));
            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization_CreateUserAuthorization, L("CreateUserAuthorization"));
            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization_EditUserAuthorization, L("EditUserAuthorization"));           
            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions. UserAuthorization_DeleteUserAuthorization, L("DeleteUserAuthorization"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CustomDomainConsts.LocalizationSourceName);
        }
    }




}