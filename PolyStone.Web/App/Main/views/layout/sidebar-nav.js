(function () {
    var controllerId = 'app.views.layout.sidebarNav';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;
            vm.menuItems = [
                createMenuItem(App.localize("HomePage"), "", "home", "home"),

                
                

                createMenuItem(App.localize("UserManagement"), "", "people", "", [
                    //createMenuItem(App.localize("Tenants"), "Pages.Tenants", "business", "tenants"),
                    createMenuItem(App.localize("Users"), "Pages.Users", "", "users"),
                    createMenuItem(App.localize("Roles"), "Pages.Roles", "", "roles")
                ]),

                createMenuItem(App.localize("ProductManagement"), "", "storage", "", [
                    createMenuItem(App.localize("Product"), "Pages.Product", "", "products"),
                    createMenuItem(App.localize("Category"), "Pages.Category", "", "category")
                    //createMenuItem(App.localize("Users"), "Pages.Users", "people", "users"),
                ]),
                createMenuItem(App.localize("CommunityManagement"), "", "public", "", [
                    createMenuItem(App.localize("Community"), "Pages.Community", "", "community"),
                    //createMenuItem(App.localize("Users"), "Pages.Users", "people", "users"),
                    createMenuItem(App.localize("CommunityCategory"), "Pages.CommunityCategory", "", "communityCategory")
                ]),
                createMenuItem(App.localize("CompanyManagement"), "", "business", "", [
                    createMenuItem(App.localize("Company"), "Pages.Company", "", "company"),
                    createMenuItem(App.localize("CompanyApplication"), "Pages.CompanyApplication", "", "companyApplication")//,
                    //createMenuItem(App.localize("CommunityCategory"), "Pages.CommunityCategory", "", "communityCategory")
                ]),
                createMenuItem(App.localize("Configuration"), "", "settings", "", [
                    createMenuItem(App.localize("Region"), "Pages.Region", "", "regions")
                ]),

                createMenuItem(App.localize("About"), "", "info", "about")
            ];

            vm.showMenuItem = function (menuItem) {
                if (menuItem.permissionName) {
                    var result = abp.auth.isGranted(menuItem.permissionName);
                    return result;
                }

                return true;
            }

            function createMenuItem(name, permissionName, icon, route, childItems) {
                return {
                    name: name,
                    permissionName: permissionName,
                    icon: icon,
                    route: route,
                    items: childItems
                };
            }
        }
    ]);
})();