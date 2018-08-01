using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.Regions.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="RegionAppPermissions"/> for all permission names.
    /// </summary>
    public class RegionAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Region 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

              var region = pages.Children.FirstOrDefault(p => p.Name == RegionAppPermissions.Region) 
                ?? pages.CreateChildPermission(RegionAppPermissions.Region, L("Region"));



           
            region.CreateChildPermission(RegionAppPermissions.Region_CreateRegion, L("CreateRegion"));
            region.CreateChildPermission(RegionAppPermissions.Region_EditRegion, L("EditRegion"));           
            region.CreateChildPermission(RegionAppPermissions. Region_DeleteRegion, L("DeleteRegion"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}