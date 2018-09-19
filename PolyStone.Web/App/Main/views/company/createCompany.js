(function () {
    angular.module('app').controller('app.views.company.createCompany', [
        '$scope', 'abp.services.app.company', 'abp.services.app.category','FileUploader',
        function ($scope, companyService, categoryService,FileUploader) {
            var vm = this;
            var imgUrls = [];
            vm.uploadResult = {
                status: true,
                msg:""
            };
            vm.categoryList = [];
            
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


            vm.product = {
                title: "",
                categoryId: "0",
                companyId:"",
                imgUrls: "",
                detail:"",
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

            uploader.onCompleteAll = function () {

                if (vm.uploadResult.status) {
                    vm.product.imgUrls = imgUrls.join(',');
                    productService.createProduct(vm.product)
                        .then(function() {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                        });
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