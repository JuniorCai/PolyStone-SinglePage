using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;



namespace PolyStone.CustomDomain.Members.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="MemberAppPermissions"/> for all permission names.
    /// </summary>
    public class MemberAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//在这里配置了Member 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var member = pages.Children.FirstOrDefault(p => p.Name == MemberAppPermissions.Member)
                                  ?? pages.CreateChildPermission(MemberAppPermissions.Member,
                                      L("Member"));

            member.CreateChildPermission(MemberAppPermissions.Member_CreateMember, L("CreateMember"));
            member.CreateChildPermission(MemberAppPermissions.Member_EditMember, L("EditMember"));
            member.CreateChildPermission(MemberAppPermissions. Member_DeleteMember, L("DeleteMember"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}