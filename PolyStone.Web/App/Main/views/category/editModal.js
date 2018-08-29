(function () {
    angular.module('app').controller('app.views.category.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.category', 'id',
        function ($scope, $uibModalInstance, categoryService, id) {
            var vm = this;

            vm.category = {
                isActive: true
            };


            var init = function() {
                categoryService.getCategoryById({ id: id })
                    .then(function(result) {
                        vm.category = result.data;
                    });
            };

            vm.save = function () {
               
                categoryService.update(vm.user)
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