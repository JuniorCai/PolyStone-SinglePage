using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;

namespace PolyStone.CustomDomain.CompanyIndustries.Industries.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="IndustryAppPermissions"/> for all permission names.
    /// </summary>
    public class IndustryAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Industry 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var industry = pages.Children.FirstOrDefault(p => p.Name == IndustryAppPermissions.Industry)
                          ?? pages.CreateChildPermission(IndustryAppPermissions.Industry, L("Industry"));





            industry.CreateChildPermission(IndustryAppPermissions.Industry_CreateIndustry, L("CreateIndustry"));
            industry.CreateChildPermission(IndustryAppPermissions.Industry_EditIndustry, L("EditIndustry"));           
            industry.CreateChildPermission(IndustryAppPermissions. Industry_DeleteIndustry, L("DeleteIndustry"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}