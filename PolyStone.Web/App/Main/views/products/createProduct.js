(function () {
    angular.module('app').controller('app.views.product.createProduct', [
        '$scope', 'abp.services.app.product', 'abp.services.app.category',
        function ($scope, productService,categoryService) {
            var vm = this;
            vm.categoryList = [];

            vm.product = {
                isActive: true,
                isDeleted:false
            };

            vm.roles = [];
            $scope.selectedCategory = "0";

            function getCategoryList() {
                categoryService.getPagedCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.categoryList = result.data.items;
                });
            }

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
            getCategoryList();
            // getRoles();
        }
    ]);
})();