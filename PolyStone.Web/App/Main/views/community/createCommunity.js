﻿(function () {
    angular.module('app').controller('app.views.community.createCommunity', [
        '$scope', 'abp.services.app.community', 'abp.services.app.communityCategory','FileUploader','$http',
        function ($scope, communityService, categoryService,FileUploader,$http) {
            var vm = this;
            var imgUrls = [];
            vm.uploadResult = {
                status: true,
                msg:""
            };
            vm.categoryList = [];
            
            var uploader = $scope.fileUploader = new FileUploader({
                url: "/Resource/Upload",
                queueLimit: 6,
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
                if (this.queue.length == 6) {
                    $("#uploadDiv").hide();
                } else {
                    $("#uploadDiv").show();
                }
            };

            vm.delImg = function() {
                //$scope.fileUploader
            };


            vm.community = {
                title: "",
                communityCategoryId: "0",
                memberId:"",
                imgUrls: "",
                detail:"",
                isActive: true,
                isDeleted: false
            };

            $scope.selectedCategory = "0";

            function getCategoryList() {
                categoryService.getPagedCommunityCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.categoryList = result.data.items;
                });
            }

            vm.save = function () {
                if ($scope.selectedCategory == "0") {
                    abp.notify.error("未选择分类");
                    return;
                } else {
                    vm.community.communityCategoryId = $scope.selectedCategory;
                    if ($.trim(vm.community.title).length == 0) {
                        abp.notify.error("圈子标题未填写");
                        return;
                    } else if (vm.community.memberId <= 0) {
                        abp.notify.error("关联企业ID无效");
                        return;
                    } else if ($.trim(vm.community.detail).lengt == 0) {
                        abp.notify.error("圈子描述未填写");
                        return;
                    }
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
                    vm.community.imgUrls = imgUrls.join(',');

                    var postUrl = $("#frm_create_community").attr("url");
                    $http.post(postUrl, { model: vm.community }).then(function() {
                        //abp.notify.info(result);

                    });
                    //communityService.createProduct(vm.product)
//                        .then(function() {
//                            abp.notify.success(App.localize('SavedSuccessfully'));
//                        });
                } else {
                    abp.notify.error(vm.uploadResult.msg);
                }                
            }

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            getCategoryList();
        }
    ]);
})();