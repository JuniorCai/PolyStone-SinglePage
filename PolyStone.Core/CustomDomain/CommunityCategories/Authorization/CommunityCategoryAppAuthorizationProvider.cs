using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.CommunityCategories.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CommunityCategoryAppPermissions"/> for all permission names.
    /// </summary>
    public class CommunityCategoryAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了CommunityCategory 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var communityCategory = pages.Children.FirstOrDefault(p => p.Name == CommunityCategoryAppPermissions.CommunityCategory) 
                ?? pages.CreateChildPermission(CommunityCategoryAppPermissions.CommunityCategory, L("CommunityCategory"));



            communityCategory.CreateChildPermission(CommunityCategoryAppPermissions.CommunityCategory_CreateCommunityCategory, L("CreateCommunityCategory"));
            communityCategory.CreateChildPermission(CommunityCategoryAppPermissions.CommunityCategory_EditCommunityCategory, L("EditCommunityCategory"));           
            communityCategory.CreateChildPermission(CommunityCategoryAppPermissions. CommunityCategory_DeleteCommunityCategory, L("DeleteCommunityCategory"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}