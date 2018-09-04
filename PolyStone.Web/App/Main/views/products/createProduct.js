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
                    return this.quere.length < 6;
                }
            });


            vm.product = {
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
                
                productService.createProduct(vm.category)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            getCategoryList();
        }
    ]);
})();