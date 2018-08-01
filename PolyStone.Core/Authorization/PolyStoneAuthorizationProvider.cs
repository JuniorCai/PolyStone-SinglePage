using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace PolyStone.Authorization
{
    public class PolyStoneAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Admin_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Admin_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Admin_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}
