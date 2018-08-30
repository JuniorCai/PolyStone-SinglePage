(function () {
    angular.module('app').controller('app.views.category.index', [
        '$scope', '$uibModal', 'abp.services.app.category',
        function ($scope, $uibModal, categoryService) {
            var vm = this;

            vm.categoryList = [];

            function getCategoryList() {
                categoryService.getPagedCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.categoryList = result.data.items;
                });
            }

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
                    getCategoryList();
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
                    getCategoryList();
                });
            };

            vm.delete = function (category) {
                abp.message.confirm(
                    "是否删除产品类别 '" + category.categoryName + "'?",
                    function (result) {
                        if (result) {
                            categoryService.deleteCategory({ id: category.id })
                                .then(function () {
                                    abp.notify.info("已删除产品类别: " + category.categoryName);
                                    getCategoryList();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getCategoryList();
            };

            getCategoryList();
        }
    ]);
})();