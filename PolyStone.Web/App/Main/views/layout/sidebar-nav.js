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

                createMenuItem(App.localize("ContentManagement"), "", "menu", "", [
                    createMenuItem(App.localize("Category"), "Pages.Category", "", "category"),
                    //createMenuItem(App.localize("Users"), "Pages.Users", "people", "users"),
                    createMenuItem(App.localize("CommunityCategory"), "Pages.CommunityCategory", "", "communityCategory")
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