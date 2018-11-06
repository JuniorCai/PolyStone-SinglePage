using System.Linq;
using Abp.Authorization;
using Abp.Localization;


namespace PolyStone.CustomDomain.UserVerifies.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UserVerifyAppPermissions"/> for all permission names.
    /// </summary>
    public class UserVerifyAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了UserVerify 的权限。

//            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
//
//              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
//                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
//
//
//
//           
//
//            var userVerify = entityNameModel.CreateChildPermission(UserVerifyAppPermissions.UserVerify , L("UserVerify"));
//            userVerify.CreateChildPermission(UserVerifyAppPermissions.UserVerify_CreateUserVerify, L("CreateUserVerify"));
//            userVerify.CreateChildPermission(UserVerifyAppPermissions.UserVerify_EditUserVerify, L("EditUserVerify"));           
//            userVerify.CreateChildPermission(UserVerifyAppPermissions. UserVerify_DeleteUserVerify, L("DeleteUserVerify"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}