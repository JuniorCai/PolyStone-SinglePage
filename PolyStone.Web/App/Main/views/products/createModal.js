(function () {
    angular.module('app').controller('app.views.product.createProduct', [
        '$scope', 'abp.services.app.product',
        function ($scope, $uibModalInstance, productService) {
            var vm = this;

            vm.product = {
                isActive: true,
                isDeleted:false
            };

            vm.roles = [];


            vm.save = function () {
                
                productService.createProduct(vm.category)
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