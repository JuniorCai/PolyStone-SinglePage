using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;

namespace PolyStone.CustomDomain.CompanyContacts.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ContactAppPermissions"/> for all permission names.
    /// </summary>
    public class ContactAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Contact 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var contact = pages.Children.FirstOrDefault(p => p.Name == ContactAppPermissions.Contact)
                                  ?? pages.CreateChildPermission(ContactAppPermissions.Contact, L("Contact"));



            contact.CreateChildPermission(ContactAppPermissions.Contact_CreateContact, L("CreateContact"));
            contact.CreateChildPermission(ContactAppPermissions.Contact_EditContact, L("EditContact"));
            contact.CreateChildPermission(ContactAppPermissions.Contact_DeleteContact, L("DeleteContact"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}