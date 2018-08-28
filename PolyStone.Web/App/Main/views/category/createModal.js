(function () {
    angular.module('app').controller('app.views.category.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.category',
        function ($scope, $uibModalInstance, categoryService) {
            var vm = this;

            vm.category = {
                isActive: true,
                isShow: true,
                isDeleted:false
            };

            vm.roles = [];

//            function getRoles() {
//                categoryService.getRoles()
//                    .then(function (result) {
//                        vm.roles = result.data.items;
//                    });
//            }

            vm.save = function () {
                
                categoryService.create(vm.category)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

           // getRoles();
        }
    ]);
})();