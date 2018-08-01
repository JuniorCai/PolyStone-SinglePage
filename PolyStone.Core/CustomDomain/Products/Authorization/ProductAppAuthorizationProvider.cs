                          

   
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.Products.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ProductAppPermissions"/> for all permission names.
    /// </summary>
    public class ProductAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Product 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var product = pages.Children.FirstOrDefault(p => p.Name == ProductAppPermissions.Product) 
                ?? pages.CreateChildPermission(ProductAppPermissions.Product, L("Product"));

            product.CreateChildPermission(ProductAppPermissions.Product_CreateProduct, L("CreateProduct"));
            product.CreateChildPermission(ProductAppPermissions.Product_EditProduct, L("EditProduct"));           
            product.CreateChildPermission(ProductAppPermissions. Product_DeleteProduct, L("DeleteProduct"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}