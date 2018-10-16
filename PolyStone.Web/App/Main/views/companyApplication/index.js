(function () {
    angular.module('app').controller('app.views.companyApplication.index', [
        '$scope', '$state', 'abp.services.app.companyApplication',
        function ($scope, $state,companyApplicationService) {
            var vm = this;

            vm.categoryList = [];

            vm.productList = [];

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



            function getApplicationList() {
                companyApplicationService.getPagedProducts({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.productList = result.data.items;
                });
            }
         




            vm.delete = function(item) {
                abp.message.confirm(
                    "是否删除产品类别 '" + item.title + "'?",
                    function(result) {
                        if (result) {
                            companyApplicationService.deleteProduct({ id: item.id })
                                .then(function() {
                                    abp.notify.info("已删除产品: " + item.title);
                                    getApplicationList();
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getApplicationList();
            };

            vm.gotoDetail = function (itemId) {
                $state.go("productEdit", { id: itemId });
            };


            initParams();
            initPickers();
            getApplicationList();
        }
    ]);
})();