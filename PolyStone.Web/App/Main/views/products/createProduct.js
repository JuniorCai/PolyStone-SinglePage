(function () {
    angular.module('app').controller('app.views.product.createProduct', [
        '$scope', 'abp.services.app.product', 'abp.services.app.category','FileUploader',
        function ($scope, productService, categoryService,FileUploader) {
            var vm = this;
            vm.categoryList = [];
            
            var uploader = $scope.fileUploader = new FileUploader({
                url:""
            });

            uploader.filters.push({
                name: 'imageFilter',
                fn: function(item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            });

            uploader.filters.push({
                name: 'countLimitFilter',
                fn:function(item, options) {
                    return this.queue.length < 6;
                }
            });

            uploader.onAfterAddingAll=function() {
                if (this.queue.length == 6) {
                    $("#uploadDiv").hide();
                } else {
                    $("#uploadDiv").show();
                }
            }

            vm.delImg = function() {
                //$scope.fileUploader
            };


            vm.product = {
                title: "",
                categoryId: "0",
                companyId:0,
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

                uploader.uploaderAll();

            };

            uploader.onCompleteAll = function (result) {
                abp.notify.info(App.localize('SavedSuccessfully'));
//                productService.createProduct(vm.product)
//                    .then(function () {
//                        abp.notify.info(App.localize('SavedSuccessfully'));
//                    });
            }

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            getCategoryList();
        }
    ]);
})();