using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace PolyStone.Authorization
{
    public class PolyStoneAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"), L("Pages"));


            pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"), L("Users"));
            pages.CreateChildPermission(PermissionNames.Pages_Roles, L("Roles"), L("Roles"));


//            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
//            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
//            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}
