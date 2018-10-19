using Abp.Application.Navigation;
using Abp.Localization;
using PolyStone.Authorization;
using PolyStone.CustomDomain.Categories.Authorization;
using PolyStone.CustomDomain.Communities.Authorization;
using PolyStone.CustomDomain.CommunityCategories.Authorization;
using PolyStone.CustomDomain.Companies.Authorization;
using PolyStone.CustomDomain.CompanyApplications.Authorization;
using PolyStone.CustomDomain.Modules.Authorization;
using PolyStone.CustomDomain.Products.Authorization;
using PolyStone.CustomDomain.Regions.Authorization;

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
                        "ProductManagement",
                        L("ProductManagement"),
                        icon: "fa fa-globe",
                        requiresAuthentication: true,
                        order: 1
                    ).AddItem(
                        new MenuItemDefinition(
                            "Products",
                            L("Product"),
                            icon: "icon-grid",
                            url: "#products",
                            requiredPermissionName: ProductAppPermissions.Product
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "Category",
                            L("Category"),
                            icon: "icon-grid",
                            url: "#category",
                            requiredPermissionName: CategoryAppPermissions.Category
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "CommunityManagement",
                        L("ContentManagement"),
                        icon: "fa fa-globe",
                        requiresAuthentication:true,
                        order:1
                    ).AddItem(
                        new MenuItemDefinition(
                            "Community",
                            L("Community"),
                            icon:"icon-grid",
                            url: "#community",
                            requiredPermissionName:CommunityAppPermissions.Community
                            )
                        ).AddItem(
                        new MenuItemDefinition(
                            "CommunityCategory",
                            L("CommunityCategory"),
                            icon: "icon-grid",
                            url: "#communityCategory",
                            requiredPermissionName: CommunityCategoryAppPermissions.CommunityCategory
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "UserManagement",
                        L("UserManagement"),
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
                        "CompanyManagement",
                        L("CompanyManagement"),
                        icon: "fa fa-cogs"
                    ).AddItem(
                        new MenuItemDefinition(
                            "Company",
                            L("Company"),
                            url: "#company",
                            icon: "fa fa-users",
                            requiredPermissionName: CompanyAppPermissions.Company
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "CompanyApplication",
                            L("CompanyApplication"),
                            url: "#companyApplications",
                            icon: "fa fa-users",
                            requiredPermissionName: CompanyApplicationAppPermissions.CompanyApplication
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Configuration",
                        L("Configuration"),
                        icon: "fa fa-csogs"
                    ).AddItem(
                        new MenuItemDefinition(
                            "Regions",
                            L("Regions"),
                            url: "#regions",
                            icon: "fa fa-users",
                            requiredPermissionName: RegionAppPermissions.Region
                        )
                    ).AddItem(new MenuItemDefinition(
                        "Module",
                        L("Module"),
                        url: "modules",
                        icon: "icon-grid",
                        requiredPermissionName: ModuleAppPermissions.Module
                    ))
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
