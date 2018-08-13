                          

   
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.CompanyApplications.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CompanyApplicationAppPermissions"/> for all permission names.
    /// </summary>
    public class CompanyApplicationAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了CompanyApplication 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var companyApplication = pages.Children.FirstOrDefault(p => p.Name == CompanyApplicationAppPermissions.CompanyApplication)
                ?? pages.CreateChildPermission(CompanyApplicationAppPermissions.CompanyApplication, L("CompanyApplication"));

            companyApplication.CreateChildPermission(CompanyApplicationAppPermissions.CompanyApplication_CreateCompanyApplication, L("CreateCompanyApplication"));
            companyApplication.CreateChildPermission(CompanyApplicationAppPermissions.CompanyApplication_EditCompanyApplication, L("EditCompanyApplication"));           
            companyApplication.CreateChildPermission(CompanyApplicationAppPermissions. CompanyApplication_DeleteCompanyApplication, L("DeleteCompanyApplication"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}