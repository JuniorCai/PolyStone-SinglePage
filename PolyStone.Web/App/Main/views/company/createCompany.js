(function () {
    angular.module('app').controller('app.views.company.createCompany', [
        '$scope', 'abp.services.app.company', 'abp.services.app.industry','abp.services.app.region','FileUploader',
        function ($scope, companyService, industryService,regionService,FileUploader) {
            var vm = this;
            var imgUrls = [];
            vm.uploadResult = {
                status: true,
                msg:""
            };
            
            var uploader = $scope.fileUploader1 = $scope.fileUploader = new FileUploader({
                url: "/Resource/Upload",
                queueLimit: 1,
                headers: {
                    'x-xsrf-token': abp.security.antiForgery.getToken()
                }
            });

            uploader.filters.push({
                name: 'imageFilter',
                fn: function(item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            });
            uploader.filters.push({
                name: 'sizeFilter',
                fn: function (item /*{File|FileLikeObject}*/, options) {

                    return item.size <= 1048576;
                }
            });
            uploader.onAfterAddingAll = function() {
                if (this.queue.length == 1) {
                    $("#uploadDiv").hide();
                } else {
                    $("#uploadDiv").show();
                }
            };

            vm.delImg = function() {
                //$scope.fileUploader
            };


            vm.company = {
                companyEditDto: {
                    companyName: "",
                    shortName: "",
                    companyType: 1,
                    logo: "",
                    memberId:0,
                    industry: "",
                    business: "",
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
                    $scope.isCityShow = false;
                } else {
                    vm.cityList = [];
                    regionService.getPagedRegions({
                        regionCode: vm.selectedProvince,
                        maxResultCount: 100,
                        sorting: "Id"
                    }).then(function (result) {
                        vm.cityList = result.data.items;
                        if (vm.cityList.length > 0) {
                            $scope.isCityShow = true;
                        } else {
                            $scope.isCityShow = false;
                        }
                    });
                    
                }
            };

            vm.save = function () {
                if (vm.selectedIndustry == "0") {
                    abp.notify.error("未选择分类");
                    return;
                } else {
//                    vm.product.categoryId = $scope.selectedIndustry;
//                    if ($.trim(vm.product.title).length == 0) {
//                        abp.notify.error("产品标题未填写");
//                        return;
//                    }else if (vm.product.companyId <= 0) {
//                        abp.notify.error("关联企业ID无效");
//                        return;
//                    } else if ($.trim(vm.product.detail).lengt == 0) {
//                        abp.notify.error("产品描述未填写");
//                        return;
//                    }
                }
                if (uploader.queue.length == 0) {
                    abp.notify.error("需上传至少一张产品图片");
                    return;
                }
                uploader.uploadAll();

            };


            uploader.onSuccessItem = function (item, response, status, headers)
            {
                vm.uploadResult.status = response.result.success;
                vm.uploadResult.msg = response.result.success ? response.result.msg : item.name + " "+response.result.msg;
                if (!vm.uploadResult.status)
                    vm.fileUploader.cancelAll();
                else {
                    imgUrls.push(response.result.msg);
                }
            };

            uploader.onErrorItem = function(item, response, status, headers) {
                vm.uploadResult.status = false;
                vm.uploadResult.msg = item.name + "上传失败";
                vm.fileUploader.cancelAll();
            };

            uploader.onCompleteAll = function () {

                if (vm.uploadResult.status) {
                    vm.product.imgUrls = imgUrls.join(',');
                    companyService.createCompany(vm.product)
                        .then(function() {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                        });
                } else {
                    abp.notify.error(vm.uploadResult.msg);
                }                
            }

            vm.cancel = function () {
            };

            initPageData();
        }
    ]);
})();