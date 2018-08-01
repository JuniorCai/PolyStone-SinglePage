using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.Communities.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CommunityAppPermissions"/> for all permission names.
    /// </summary>
    public class CommunityAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Community 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var community = pages.Children.FirstOrDefault(p => p.Name == CommunityAppPermissions.Community) 
                ?? pages.CreateChildPermission(CommunityAppPermissions.Community, L("Community"));

            community.CreateChildPermission(CommunityAppPermissions.Community_CreateCommunity, L("CreateCommunity"));
            community.CreateChildPermission(CommunityAppPermissions.Community_EditCommunity, L("EditCommunity"));           
            community.CreateChildPermission(CommunityAppPermissions. Community_DeleteCommunity, L("DeleteCommunity"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}