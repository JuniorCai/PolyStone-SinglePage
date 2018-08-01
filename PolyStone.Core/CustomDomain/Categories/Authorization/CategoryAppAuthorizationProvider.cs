using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.Categories.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CategoryAppPermissions"/> for all permission names.
    /// </summary>
    public class CategoryAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//在这里配置了Category 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var category = pages.Children.FirstOrDefault(p => p.Name == CategoryAppPermissions.Category)
                ?? pages.CreateChildPermission(CategoryAppPermissions.Category, L("Category"));


            category.CreateChildPermission(CategoryAppPermissions.Category_CreateCategory, L("CreateCategory"));
            category.CreateChildPermission(CategoryAppPermissions.Category_EditCategory, L("EditCategory"));           
            category.CreateChildPermission(CategoryAppPermissions. Category_DeleteCategory, L("DeleteCategory"));
 
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}