(function () {
    angular.module('app').controller('app.views.company.createCompany', [
        '$scope', 'abp.services.app.user', 'abp.services.app.company', 'abp.services.app.industry', 'abp.services.app.region', 'FileUploader', '$http',
        function ($scope,userService, companyService, industryService,regionService,FileUploader,$http) {
            var vm = this;
            var imgUrls = [];
            vm.showAuthBlock = false;
            vm.uploadResult1 = {
                status: true,
                msg:""
            };
            vm.uploadResult2 = {
                status: true,
                msg: ""
            };
            vm.uploadResult3 = {
                status: true,
                msg: ""
            };
            vm.uploadResult4 = {
                status: true,
                msg: ""
            };

            var fileUploaderCfg = {
                url: "/Resource/Upload",
                queueLimit: 1,
                headers: {
                    'x-xsrf-token': abp.security.antiForgery.getToken()
                }
            };

            var imageFilter = {
                name: 'imageFilter',
                fn: function(item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            };

            var sizeFilter = {
                name: 'sizeFilter',
                fn: function (item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            };
            
            var fileUploader1 = $scope.logoFileUploader = new FileUploader(fileUploaderCfg);
            var fileUploader2 = $scope.licenceFileUploader = new FileUploader(fileUploaderCfg);
            var fileUploader3 = $scope.personFileUploader = new FileUploader(fileUploaderCfg);
            var fileUploader4 = $scope.nationalFileUploader = new FileUploader(fileUploaderCfg);


            fileUploader1.filters.push(imageFilter);
            fileUploader1.filters.push(sizeFilter);

            fileUploader2.filters.push(imageFilter);
            fileUploader2.filters.push(sizeFilter);

            fileUploader3.filters.push(imageFilter);
            fileUploader3.filters.push(sizeFilter);

            fileUploader4.filters.push(imageFilter);
            fileUploader4.filters.push(sizeFilter);

            fileUploader1.onAfterAddingFile = function() {
                toggleUploadDiv("#logoUploadDiv", this.queue.length >= 1);
            };
            fileUploader2.onAfterAddingFile = function () {
                toggleUploadDiv("#licenseUploadDiv", this.queue.length >= 1);
            };
            fileUploader3.onAfterAddingFile = function () {
                toggleUploadDiv("#personUploadDiv", this.queue.length >= 1);

            };
            fileUploader4.onAfterAddingFile = function () {
                toggleUploadDiv("#nationalUploadDiv", this.queue.length >= 1);
            };

            function toggleUploadDiv(divId, isHide) {
                if (isHide) {
                    $(divId).hide();
                } else {
                    $(divId).show();
                }
            }

            vm.delImg = function() {
                //$scope.fileUploader
            };


            vm.company = {
                companyEditDto: {
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
                contactEditDto: {
                    companyId: -1,
                    linkMan: "",
                    phone: "",
                    tel: "",
                    email: "",
                    isDefault:false
                }
            };

            function initPageData() {
                getIndustryList();
                getRegionList();
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

            vm.chooseRegion = function () {
                if (vm.selectedProvince == "-1") {
                    vm.isCityShow = false;
                } else {
                    vm.selectedRegion = vm.selectedProvince.id;
                    vm.cityList = [];
                    regionService.getPagedRegions({
                        regionCode: vm.selectedProvince.regionCode,
                        maxResultCount: 100,
                        sorting: "Id"
                    }).then(function (result) {
                        vm.cityList = result.data.items;
                        if (vm.cityList.length > 0) {
                            vm.selectedRegion = 0;
                            vm.isCityShow = true;
                        } else {
                            vm.isCityShow = false;
                        }
                    });
                    
                }
            };

            vm.chooseCity = function() {
                vm.selectedRegion = vm.selectedCity.id;
            }

            vm.save = function () {
                if ($.trim(vm.company.companyEditDto.userName).length == 0) {
                    abp.notify.error("请填写需要关联的用户名");
                    return false;
                } else {
                    userService.isUserNameExist(vm.company.companyEditDto.userName)
                        .then(function (result) {
                            if (result.data==null)
                                abp.notify.error("所关联的用户名不存在!");
                            else {
                                vm.company.companyEditDto.memberId = result.data.id;
                                var flag = bindCompanyInfo();
                                if (flag) {
                                    if (vm.showAuthBlock) {
                                        bindAuthInfo();
                                    } else {
                                        vm.company.companyAuthEditDto = null;
                                        vm.company.contactEditDto = null;
                                        postData();
                                    }
                                }
                            }
                        });
                }
                
            };

            function bindCompanyInfo() {
                if (vm.selectedIndustry == "-1") {
                    abp.notify.error("未选择行业分类");
                    return false;
                } else if (vm.selectedRegion <= 0) {
                    abp.notify.error("未选择所在地区");
                    return false;
                }
                else {
                    vm.company.companyEditDto.industry = vm.selectedIndustry;
                    vm.company.companyEditDto.regionId = vm.selectedRegion;
                    if ($.trim(vm.company.companyEditDto.companyName).length == 0) {
                        abp.notify.error("企业全称未填写");
                        return false;
                    } else if ($.trim(vm.company.companyEditDto.shortName).length == 0) {
                        abp.notify.error("企业简称未填写");
                        return false;
                    }
                }

                if (fileUploader1.queue.length > 0) {
                    fileUploader1.uploadAll();
                    return false;
                } else {
                    return true;
                }
            }

            function bindAuthInfo() {
                if (fileUploader2.queue.length == 0) {
                    abp.notify.error("请上传营业执照");
                    return;
                }
                if ($.trim(vm.company.companyAuthEditDto.legalPerson).length == 0) {
                    abp.notify.error("未填写法人姓名");
                    return;
                }
                if (fileUploader3.queue.length == 0) {
                    abp.notify.error("请上传法人身份证人像照");
                    return;
                }
                if (fileUploader3.queue.length == 0) {
                    abp.notify.error("请上传法人身份证国徽照");
                    return;
                }
                fileUploader2.uploadAll();
            }

            function postData() {
                var postUrl = $("#frm_create_company").attr("url");
                $http.post(postUrl, { model: vm.company }).then(function (result) {
                    if (result.data.success) {
                        abp.notify.info("保存成功");
                    } else {
                        abp.notify.error("保存失败");
                    }

                });

//                companyService.createCompany(vm.company)
//                    .then(function (result) {
//                        abp.notify.success(App.localize('SavedSuccessfully'));
//                    });
            }


            fileUploader1.onSuccessItem = function(item, response) {
                vm.uploadResult1.status = response.result.success;
                vm.uploadResult1.msg =
                    response.result.success ? response.result.msg : item.name + " " + response.result.msg;
                if (!vm.uploadResult1.status) {
                    fileUploader1.cancelAll();
                }
            };
            fileUploader1.onCompleteAll = function() {
                if (vm.uploadResult1.status) {
                    vm.company.companyEditDto.logo = vm.uploadResult1.msg;
                    if (!vm.showAuthBlock) {
                        postData();
                    }else {
                        bindAuthInfo();
                    }
                } else {
                    abp.notify.error("企业logo上传失败");
                }
            };

            fileUploader2.onSuccessItem = function (item, response) {
                vm.uploadResult2.status = response.result.success;
                vm.uploadResult2.msg = response.result.success ? response.result.msg : item.name + " " + response.result.msg;
                if (!vm.uploadResult2.status) {
                    abp.notify.error("请上传营业执照");
                    fileUploader2.cancelAll();
                }
                else {
                    vm.company.companyAuthEditDto.license = vm.uploadResult2.msg;
                    fileUploader3.uploadAll();
                }
            };
            fileUploader3.onSuccessItem = function (item, response) {
                vm.uploadResult3.status = response.result.success;
                vm.uploadResult3.msg = response.result.success ? response.result.msg : item.name + " " + response.result.msg;
                if (!vm.uploadResult3.status) {
                    abp.notify.error("请上传法人身份证人像照");
                    fileUploader3.cancelAll();
                }
                else {
                    vm.company.companyAuthEditDto.frontImg = vm.uploadResult3.msg;
                    fileUploader4.uploadAll();
                }
            };
            fileUploader4.onSuccessItem = function (item, response) {
                vm.uploadResult4.status = response.result.success;
                vm.uploadResult4.msg = response.result.success ? response.result.msg : item.name + " " + response.result.msg;
                if (!vm.uploadResult4.status) {
                    abp.notify.error("请上传法人身份证国徽照");
                    fileUploader4.cancelAll();
                }
                else
                    vm.company.companyAuthEditDto.backImg = vm.uploadResult4.msg;
            };

            fileUploader4.onCompleteAll = function () {
                if (vm.uploadResult1.status &&
                    vm.uploadResult2.status &&
                    vm.uploadResult3.status &&
                    vm.uploadResult4.status) {
                    postData();
                }


//                if (vm.uploadResult.status) {
//                    vm.product.imgUrls = imgUrls.join(',');
//                    companyService.createCompany(vm.product)
//                        .then(function() {
//                            abp.notify.success(App.localize('SavedSuccessfully'));
//                        });
//                } else {
//                    abp.notify.error(vm.uploadResult.msg);
//                }                
            }

            vm.cancel = function () {
            };

            initPageData();
        }
    ]);
})();