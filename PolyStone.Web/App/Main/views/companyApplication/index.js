(function () {
    angular.module('app').controller('app.views.companyApplication.index', [
        '$scope', '$state', 'abp.services.app.companyApplication',
        function ($scope, $state,companyApplicationService) {
            var vm = this;


            vm.applicationList = [];
            $scope.selectedRelease = "-1";

            function initParams() {
                vm.search = {
                    applicationId: 0,
                    companyName: "",
                    regionId:"-1",
                    companyType: 0,
                    authStatus: "-1",
                    fromDate: "",
                    endDate: ""
                };
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
                companyApplicationService.getPagedCompanyApplications({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.applicationList = result.data.items;
                });
            }
         




            vm.delete = function(item) {
                abp.message.confirm(
                    "是否删除企业申请 '" + item.title + "'?",
                    function(result) {
                        if (result) {
                            companyApplicationService.deleteCompanyApplication({ id: item.id })
                                .then(function() {
                                    abp.notify.info("已删除企业申请: " + item.title);
                                    getApplicationList();
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getApplicationList();
            };

            vm.gotoDetail = function (itemId) {
                $state.go("companyApplicationEdit", { id: itemId });
            };


            initParams();
            initPickers();
            getApplicationList();
        }
    ]);
})();