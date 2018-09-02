(function () {
    angular.module('app').controller('app.views.product.index', [
        '$scope','$location', '$uibModal', 'abp.services.app.product', 'abp.services.app.category',
        function ($scope, $location, $uibModal,productService, categoryService) {
            var vm = this;

            vm.categoryList = [];

            vm.productList = [];

            $scope.selectedCategory = "0";

            function getCategoryList() {
                categoryService.getPagedCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.categoryList = result.data.items;
                });
            }


            function getProductList() {
                productService.getPagedProducts({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.productList = result.data.items;
                });
            }

            vm.goToProductDetail = function(path) {
                $location.path(path);
            };

            vm.openCategoryCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/category/createModal.cshtml',
                    controller: 'app.views.category.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getProductList();
                });
            };

            vm.openCategoryEditModal = function (category) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/category/editModal.cshtml',
                    controller: 'app.views.category.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return category.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getProductList();
                });
            };

            vm.delete = function (category) {
                abp.message.confirm(
                    "是否删除产品类别 '" + category.categoryName + "'?",
                    function (result) {
                        if (result) {
                            productService.deleteCategory({ id: category.id })
                                .then(function () {
                                    abp.notify.info("已删除产品类别: " + category.categoryName);
                                    getProductList();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getProductList();
            };

            getProductList();
            getCategoryList();
        }
    ]);
})();