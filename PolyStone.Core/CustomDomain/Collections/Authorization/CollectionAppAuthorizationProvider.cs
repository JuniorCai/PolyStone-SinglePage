using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using PolyStone.Authorization;


namespace PolyStone.CustomDomain.Collections.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CollectionAppPermissions"/> for all permission names.
    /// </summary>
    public class CollectionAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Collection 的权限。

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"), L("Pages"));



            var collection = pages.Children.FirstOrDefault(p => p.Name == CollectionAppPermissions.Collection)
                             ?? pages.CreateChildPermission(CollectionAppPermissions.Collection, L("Collection"));


            collection.CreateChildPermission(CollectionAppPermissions.Collection_CreateCollection,
                L("CreateCollection"));
            collection.CreateChildPermission(CollectionAppPermissions.Collection_EditCollection, L("EditCollection"));
            collection.CreateChildPermission(CollectionAppPermissions.Collection_DeleteCollection,
                L("DeleteCollection"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}