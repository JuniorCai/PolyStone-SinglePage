(function () {
    angular.module('app').controller('app.views.companyApplication.editCompany', [
        '$scope', '$state','$stateParams', 'abp.services.app.companyApplication', 'abp.services.app.region', '$http','$timeout',
        function ($scope, $state, $stateParams, companyApplicationService, regionService , $http, $timeout) {
            var vm = this;






            vm.application = {};

            vm.contactEditList = [];
            vm.selectedCompanyType = "0";

            function initPageData() {
                getRegionList();
            }

            function initCompanyApplication() {
                var applicationId = $stateParams.id;
                companyApplicationService.getCompanyApplicationById({ id: applicationId }).then(function(result) {
                    vm.application = result.data;
                    
                    vm.selectedRegion = result.data.region;
                    vm.selectedCompanyType = result.data.companyType.toString();
                    bindRegionSelect();
                });
            }

            function bindRegionSelect() {
                
                angular.forEach(vm.regionList, function (item, index) {
                    if (item.regionCode == vm.selectedRegion.parentCode) {
                        vm.selectedProvince = item;
                        vm.chooseRegion(true);
                    } else if (item.regionCode == vm.selectedRegion.regionCode) {
                        vm.selectedProvince = item;
                    }
                });
            }

            vm.regionList = [];
            vm.cityList = [];

            vm.selectedProvince = "-1";
            vm.selectedCity = "-1";
            vm.selectedRegion = 0;
            vm.isCityShow = false;


            function getRegionList() {
                regionService.getPagedRegions({
                    regionCode: "",
                    maxResultCount:100,
                    sorting: "Id"
                }).then(function (result) {
                    vm.regionList = result.data.items;
                });
            }


            vm.chooseRegion = function (isFirstBind = false) {

                if (vm.selectedProvince == "-1") {
                    vm.isCityShow = false;
                } else {
                    vm.selectedRegion = vm.selectedProvince;
                    vm.cityList = [];
                    regionService.getPagedRegions({
                        regionCode: vm.selectedProvince.regionCode,
                        maxResultCount: 100,
                        sorting: "Id"
                    }).then(function (result) {
                        vm.cityList = result.data.items;
                        if (vm.cityList.length > 0) {
                            if (isFirstBind) {
                                angular.forEach(vm.cityList,
                                    function(item, index) {
                                        if (item.regionCode == vm.application.region.regionCode) {
                                            vm.selectedCity = item;
                                            vm.chooseCity();
                                        }
                                    });
                            } else {
                                vm.selectedRegion = 0;
                            }
                            vm.isCityShow = true;
                        } else {
                            vm.isCityShow = false;
                        }
                    });
                    
                }
            };

            vm.chooseCity = function() {
                vm.selectedRegion = vm.selectedCity;
            };


            vm.save = function () {
            };


            function postData(deferParam) {
                var postUrl = $("#frm_create_company").attr("url");


                $http.post(postUrl, { model: vm.company }).then(function (result) {
                    if (result.data.success) {
                        abp.notify.success("保存成功", "", { timeOut: 1500 });
                        $timeout(function () {
                            $state.go("companyApplications");
                        }, 2000);
                    } else {
                        abp.notify.error(result.data.msg);
                    }

                });
            }



            vm.cancel = function () {
                $state.go("companyApplications");
            };
            initPageData();
            $timeout(function() {
                initCompanyApplication();
                },500);

        }
    ]);
})();