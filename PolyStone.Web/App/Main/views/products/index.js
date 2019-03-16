(function () {
    angular.module('app').controller('app.views.product.index', [
        '$scope','$state', '$location', '$uibModal', 'abp.services.app.product', 'abp.services.app.category',
        function ($scope, $state, $location, $uibModal,productService, categoryService) {
            var vm = this;

            vm.categoryList = [];

            vm.productList = [];
            //Pagination Config
            $scope.maxPageNumber = 6;
            $scope.totalItems = 0;
            //每页显示条数(默认10条)
            $scope.pageSize = 5;

            $scope.pageIndex = 1;
            $scope.selectedCategory = "0";

            function initParams() {
                vm.search = {
                    productId: 0,
                    title: "",
                    categoryId:"-1",
                    companyId: 0,
                    verifyStatus: "-1",
                    releaseStatus:"-1",
                    fromDate: "",
                    endDate: ""
                };

                $scope.selectedCategory = "-1";
                $scope.selectedVerify = "-1";
                $scope.selectedRelease = "-1";
            }

            function initPickers() {
                //init date pickers
                $('.date-picker').datepicker({
                    rtl: false,
                    autoclose: true,
                    language: 'zh-CN',
                    pickerPosition: 'top-right',
                    format: 'yyyy-mm-dd'
                });
            }

            function getCategoryList() {
                categoryService.getPagedCategorys({
                    filterText: "",
                    sorting: "CreationTime",
                    getActive: true
                }).then(function(result) {
                    vm.categoryList = result.data.items;
                });
            }

            vm.resetSearch = function () {
                initParams();
            };


            vm.getProductList = function(page) {
                var searchParams = {
                    id: vm.search.productId,
                    title: vm.search.title,
                    companyName: vm.search.companyName,
                    categoryId: $scope.selectedCategory,
                    verifyStatus: $scope.selectedVerify,
                    releaseStatus: $scope.selectedRelease,
                    fromTime: vm.search.fromDate,
                    endTime: vm.search.endDate,
                    sorting: "CreationTime",
                    maxResultCount: $scope.pageSize,
                    skipCount: (page - 1) * $scope.pageSize
                };

                productService.getPagedProducts(searchParams).then(function(result) {
                    vm.productList = result.data.items;
                    $scope.totalItems = result.data.totalCount;
                });
            }
         

            vm.goToProductDetail = function(path) {
                $location.path(path);
            };


//            vm.openCategoryEditModal = function (category) {
//                var modalInstance = $uibModal.open({
//                    templateUrl: '/App/Main/views/category/editModal.cshtml',
//                    controller: 'app.views.category.editModal as vm',
//                    backdrop: 'static',
//                    resolve: {
//                        id: function () {
//                            return category.id;
//                        }
//                    }
//                });
//
//                modalInstance.rendered.then(function () {
//                    $.AdminBSB.input.activate();
//                });
//
//                modalInstance.result.then(function () {
//                    getProductList();
//                });
//            };

            vm.delete = function(item) {
                abp.message.confirm(
                    "是否删除产品类别 '" + item.title + "'?",
                    function(result) {
                        if (result) {
                            productService.deleteProduct({ id: item.id })
                                .then(function() {
                                    abp.notify.info("已删除产品: " + item.title);
                                    getProductList(1);
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getProductList(1);
            };

            vm.gotoDetail = function (itemId) {
                $state.go("productEdit", { id: itemId });
            };


            initParams();
            initPickers();
            vm.getProductList($scope.pageIndex);
            getCategoryList();
        }
    ]);
})();