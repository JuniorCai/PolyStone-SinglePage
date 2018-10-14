(function () {
    angular.module('app').controller('app.views.product.createProduct', [
        '$scope', '$state', '$timeout', 'abp.services.app.product', 'abp.services.app.category', 'FileUploader','$http',
        function ($scope, $state, $timeout, productService, categoryService,FileUploader,$http) {
            var vm = this;
            var imgUrls = [];

            vm.verify = 0;
            vm.release = 0;

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

            vm.product = {
                title: "",
                categoryId: "0",
                companyId:"",
                imgUrls: "",
                detail: "",
                verifyStatus: 0,
                releaseStatus:0,
                isActive: true,
                isDeleted:false
            };

            $scope.selectedCategory = "0";

            function getCategoryList() {
                categoryService.getPagedCategorys({
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
                    vm.product.categoryId = $scope.selectedCategory;
                    if ($.trim(vm.product.title).length == 0) {
                        abp.notify.error("产品标题未填写");
                        return;
                    }else if (vm.product.companyId <= 0) {
                        abp.notify.error("关联企业ID无效");
                        return;
                    } else if ($.trim(vm.product.detail).lengt == 0) {
                        abp.notify.error("产品描述未填写");
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

            uploader.onCompleteAll = function() {
                vm.product.verifyStatus = angular.element(".btn.yellow-gold.active").attr("value");
                vm.product.releaseStatus = angular.element(".btn.yellow-lemon.active").attr("value");

                if (vm.uploadResult.status) {
                    vm.product.imgUrls = imgUrls.join(',');
                    postData();
//                    productService.createProduct(vm.product)
//                        .then(function() {
//                            abp.notify.success(App.localize('SavedSuccessfully'));
//
//                            $timeout(function() {
//                                    $state.go("products");
//                                },
//                                2000);
//                        });
                } else {
                    abp.notify.error(vm.uploadResult.msg);
                }
            };

            function postData() {
                var postUrl = $("#form_create_product").attr("url");

                $http.post(postUrl, { model: vm.product }).then(function (result) {
                    if (result.data.success) {
                        abp.notify.success("保存成功", "", { timeOut: 1500 });
                        $timeout(function () {
                            $state.go("products");
                        }, 2000);
                    } else {
                        abp.notify.error(result.data.msg);
                    }

                });
            }


            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            getCategoryList();
            //$("label .btn").button();
        }
    ]);
})();