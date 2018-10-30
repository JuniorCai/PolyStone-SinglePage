using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;
using PolyStone.CustomDomain.CompanyContacts.Authorization;

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




            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var userAuthorization = pages.Children.FirstOrDefault(p => p.Name == UserAuthorizationAppPermissions.UserAuthorization)
                          ?? pages.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization, L("UserAuthorization"));




            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization_CreateUserAuthorization, L("CreateUserAuthorization"));
            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions.UserAuthorization_EditUserAuthorization, L("EditUserAuthorization"));           
            userAuthorization.CreateChildPermission(UserAuthorizationAppPermissions. UserAuthorization_DeleteUserAuthorization, L("DeleteUserAuthorization"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}