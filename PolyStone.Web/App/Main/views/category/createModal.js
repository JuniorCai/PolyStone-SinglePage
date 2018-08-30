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


            vm.save = function () {
                
                categoryService.createCategory(vm.category)
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