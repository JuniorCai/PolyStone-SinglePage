using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;
using PolyStone.CustomDomain.Companies.Authorization;


namespace PolyStone.CustomDomain.Modules.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ModuleAppPermissions"/> for all permission names.
    /// </summary>
    public class ModuleAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//在这里配置了Module 的权限。
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var module = pages.Children.FirstOrDefault(p => p.Name == ModuleAppPermissions.Module)
                          ?? pages.CreateChildPermission(ModuleAppPermissions.Module, L("Module"));

            module.CreateChildPermission(ModuleAppPermissions.Module_CreateModule, L("CreateModule"));
            module.CreateChildPermission(ModuleAppPermissions.Module_EditModule, L("EditModule"));           
            module.CreateChildPermission(ModuleAppPermissions. Module_DeleteModule, L("DeleteModule"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }




}