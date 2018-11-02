(function () {
    angular.module('app').controller('app.views.users.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user', 'id',
        function ($scope, $uibModalInstance, userService, id) {
            var vm = this;

            vm.user = {
                isActive: true
            };
            vm.selectRoleName = "";

            vm.roles = [];

            var setAssignedRoles = function (user, roles) {
                vm.selectRoleName = user.roles.length > 0 ? user.roles[0] : "";
            }

            var init = function () {
                userService.getRoles()
                    .then(function (result) {
                        vm.roles = result.data.items;

                        userService.get({ id: id })
                            .then(function (result) {
                                vm.user = result.data;
                                setAssignedRoles(vm.user, vm.roles);
                            });
                    });
            }

            vm.chooseRole = function(roleName) {
                vm.selectRoleName = roleName;
            }

            vm.save = function () {
                if (vm.selectRoleName == "") {
                    abp.notify.warn("未对用户选择角色");
                    return;
                }
                var assingnedRoles = [];

                assingnedRoles.push(vm.selectRoleName);


                vm.user.roleNames = assingnedRoles;
                userService.update(vm.user)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            init();
        }
    ]);
})();