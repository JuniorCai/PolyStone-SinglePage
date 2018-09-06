(function () {
    angular.module('app').controller('app.views.product.createProduct', [
        '$scope', 'abp.services.app.product', 'abp.services.app.category','FileUploader',
        function ($scope, productService, categoryService,FileUploader) {
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


            vm.product = {
                title: "",
                categoryId: "0",
                companyId:1,
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