(function () {
    angular.module('app').controller('app.views.company.editCompany', [
        '$scope', '$state','$stateParams', 'abp.services.app.user', 'abp.services.app.company', 'abp.services.app.industry', 'abp.services.app.region', 'abp.services.app.contact', 'FileUploader', '$http','$timeout',
        function ($scope, $state, $stateParams, userService, companyService, industryService, regionService,contactService, FileUploader, $http, $timeout) {
            var vm = this;






            vm.application = {
                companyEditDto: {
                    id:0,
                    companyName: "",
                    shortName: "",
                    userName: "",
                    companyType: 1,
                    logo: "",
                    memberId:0,
                    industry: "",
                    bussiness: "",
                    regionId: "-1",
                    introduction: "",
                    isAuthed: true,
                    isActive: true
                },
                companyAuthEditDto: {
                    companyId: -1,
                    legalPerson: "",
                    frontImg: "",
                    backImg: "",
                    license:""
                },
            };

            vm.contactEditList = [];

            function initPageData() {
                getRegionList();
                getIndustryList();
            }

            function initCompanyApplication() {
                var companyId = $stateParams.id;
                companyService.getCompanyById({ id: companyId }).then(function(result) {
                    vm.company.companyEditDto = result.data;
                    if (result.data.companyAuth != null) {
                        vm.company.companyAuthEditDto = result.data.companyAuth;
                        vm.showAuthBlock = true;
                    } else {
                        vm.showAuthBlock = false;
                    }
                    vm.contactEditList = result.data.contacts;
                    vm.company.companyEditDto.userName = result.data.user.userName;
                    vm.selectedIndustry = result.data.industries[0].industryId.toString();
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

            vm.industryList = [];
            vm.regionList = [];
            vm.cityList = [];

            vm.selectedIndustry = "-1";
            vm.selectedProvince = "-1";
            vm.selectedCity = "-1";
            vm.selectedRegion = 0;
            vm.isCityShow = false;

            function getIndustryList() {
                industryService.getPagedIndustrys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.industryList = result.data.items;
                });
            }

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
                                        if (item.regionCode == vm.company.companyEditDto.region.regionCode) {
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
                if ($.trim(vm.company.companyEditDto.userName).length == 0) {
                    abp.notify.error("请填写需要关联的用户名");
                    return false;
                } else {
                    if (angular.element("#isUserValid").val() > 0) {
                        vm.company.companyEditDto.userId = angular.element("#isUserValid").val();
                        if (bindCompanyInfo()) {
                            if (vm.showAuthBlock) {
                                if (bindAuthInfo()) {
                                    uploadFile();
                                }
                            } else {
                                vm.company.companyAuthEditDto = null;

                                if (fileUploader1.queue.length > 0) {
                                    fileUploader1.uploadAll();
                                } else {
                                    postData();
                                }

                            }
                        }
                    } else {
                        abp.notify.error("所关联的用户名不存在!");
                    }

                    
                }
            };


            function bindCompanyInfo() {
                if (vm.selectedCompanyType == "-1") {
                    abp.notify.error("未选择企业类别");
                    return false;
                }else if (vm.selectedIndustry == "-1") {
                    abp.notify.error("未选择行业分类");
                    return false;
                } else if (vm.selectedRegion <= 0) {
                    abp.notify.error("未选择所在地区");
                    return false;
                }
                else {
                    vm.company.companyEditDto.industry = vm.selectedIndustry;
                    vm.company.companyEditDto.regionId = vm.selectedRegion.id;
                    vm.company.companyEditDto.companyType = vm.selectedCompanyType;
                    if ($.trim(vm.company.companyEditDto.companyName).length == 0) {
                        abp.notify.error("企业全称未填写");
                        return false;
                    } else if ($.trim(vm.company.companyEditDto.shortName).length == 0) {
                        abp.notify.error("企业简称未填写");
                        return false;
                    }
                }
                return true;
            }

            function bindAuthInfo() {
                if (vm.company.companyAuthEditDto.license.length==0&&fileUploader2.queue.length == 0) {
                    abp.notify.error("请上传营业执照");
                    return false;
                }
                if ($.trim(vm.company.companyAuthEditDto.legalPerson).length == 0) {
                    abp.notify.error("未填写法人姓名");
                    return false;
                }
                if (vm.company.companyAuthEditDto.frontImg.length == 0 &&fileUploader3.queue.length == 0) {
                    abp.notify.error("请上传法人身份证人像照");
                    return false;
                }
                if (vm.company.companyAuthEditDto.backImg.length == 0 &&fileUploader4.queue.length == 0) {
                    abp.notify.error("请上传法人身份证国徽照");
                    return false;
                }
                return true;

            }

            function postData(deferParam) {
                var postUrl = $("#frm_create_company").attr("url");

                //防止JSON过长无法提交，无业务功能
                vm.company.companyEditDto.contacts = [];
                vm.company.companyEditDto.industries = [];

                $http.post(postUrl, { model: vm.company }).then(function (result) {
                    if (result.data.success) {
                        abp.notify.success("保存成功", "", { timeOut: 1500 });
                        $timeout(function () {
                            $state.go("company");
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