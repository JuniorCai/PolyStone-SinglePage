using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.CompanyAuths.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CompanyAuthAppPermissions"/> for all permission names.
    /// </summary>
    public class CompanyAuthAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了CompanyAuth 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var companyAuth = pages.Children.FirstOrDefault(p => p.Name == CompanyAuthAppPermissions.CompanyAuth) 
                ?? pages.CreateChildPermission(CompanyAuthAppPermissions.CompanyAuth, L("CompanyAuth"));



           

            companyAuth.CreateChildPermission(CompanyAuthAppPermissions.CompanyAuth_CreateCompanyAuth, L("CreateCompanyAuth"));
            companyAuth.CreateChildPermission(CompanyAuthAppPermissions.CompanyAuth_EditCompanyAuth, L("EditCompanyAuth"));           
            companyAuth.CreateChildPermission(CompanyAuthAppPermissions. CompanyAuth_DeleteCompanyAuth, L("DeleteCompanyAuth"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}