using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;

namespace PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CompanyIndustryAppPermissions"/> for all permission names.
    /// </summary>
    public class CompanyIndustryAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了CompanyIndustry 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var companyIndustry =
                pages.Children.FirstOrDefault(p => p.Name == CompanyIndustryAppPermissions.CompanyIndustry)
                ?? pages.CreateChildPermission(CompanyIndustryAppPermissions.CompanyIndustry, L("CompanyIndustry"));


            companyIndustry.CreateChildPermission(CompanyIndustryAppPermissions.CompanyIndustry_CreateCompanyIndustry,
                L("CreateCompanyIndustry"));
            companyIndustry.CreateChildPermission(CompanyIndustryAppPermissions.CompanyIndustry_EditCompanyIndustry,
                L("EditCompanyIndustry"));
            companyIndustry.CreateChildPermission(CompanyIndustryAppPermissions.CompanyIndustry_DeleteCompanyIndustry,
                L("DeleteCompanyIndustry"));







        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}