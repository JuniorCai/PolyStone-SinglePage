using System.Linq;
using Abp.Authorization;
using Abp.Localization;


namespace PolyStone.CustomDomain.BusinessCard.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BusinessCardAppPermissions"/> for all permission names.
    /// </summary>
    public class BusinessCardAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了BusinessCard 的权限。

//            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
//
//              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
//                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
//
//
//
//           
//
//            var businessCard = entityNameModel.CreateChildPermission(BusinessCardAppPermissions.BusinessCard , L("BusinessCard"));
//            businessCard.CreateChildPermission(BusinessCardAppPermissions.BusinessCard_CreateBusinessCard, L("CreateBusinessCard"));
//            businessCard.CreateChildPermission(BusinessCardAppPermissions.BusinessCard_EditBusinessCard, L("EditBusinessCard"));           
//            businessCard.CreateChildPermission(BusinessCardAppPermissions. BusinessCard_DeleteBusinessCard, L("DeleteBusinessCard"));
// 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}