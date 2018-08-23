using Abp.Application.Navigation;
using Abp.Localization;
using PolyStone.Authorization;
using PolyStone.CustomDomain.Categories.Authorization;

namespace PolyStone.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class PolyStoneNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {



            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", PolyStoneConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "ContentManagement",
                        L("ContentManagement"),
                        icon: "fa fa-globe",
                        requiresAuthentication:true,
                        order:1
                    ).AddItem(
                        new MenuItemDefinition(
                            "Category",
                            L("Category"),
                            icon:"icon-grid",
                            url:"#category",
                            requiredPermissionName:CategoryAppPermissions.Category
                            )
                        ).AddItem(
                        new MenuItemDefinition(
                            "CommunityCategory",
                            L("CommunityCategory"),
                            icon: "icon-grid",
                            url: "#communityCategory",
                            requiredPermissionName: CategoryAppPermissions.Category
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "System",
                        L("System"),
                        icon: "fa fa-cogs"
                    ).AddItem(
                        new MenuItemDefinition(
                            "Users",
                            L("Users"),
                            url: "#users",
                            icon: "fa fa-users",
                            requiredPermissionName: PermissionNames.Pages_Users
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "Roles",
                            L("Roles"),
                            url: "#users",
                            icon: "fa fa-tag",
                            requiredPermissionName: PermissionNames.Pages_Roles
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", PolyStoneConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PolyStoneConsts.LocalizationSourceName);
        }
    }
}
