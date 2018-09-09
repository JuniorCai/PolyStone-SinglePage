(function () {
    angular.module('app').controller('app.views.community.index', [
        '$scope','$location', 'abp.services.app.community', 'abp.services.app.communityCategory',
        function ($scope, $location, communityService, communityCategory) {
            var vm = this;

            vm.categoryList = [];

            vm.communityList = [];

            $scope.selectedCategory = "-1";
            $scope.selectedVerify = "-1";
            $scope.selectedRelease = "-1";

            function getCategoryList() {
                communityCategory.getPagedCommunityCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.categoryList = result.data.items;
                });
            }


            function getCommunityList() {
                communityService.getPagedCommunitys
                ({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.communityList = result.data.items;
                });
            }

            vm.goToProductDetail = function(path) {
                $location.path(path);
            };


            vm.delete = function(category) {
                abp.message.confirm(
                    "是否删除产品类别 '" + category.categoryName + "'?",
                    function(result) {
                        if (result) {
                            communityService.deleteCategory({ id: category.id })
                                .then(function() {
                                    abp.notify.info("已删除产品类别: " + category.categoryName);
                                    getCommunityList();
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getCommunityList();
            };

            getCommunityList();
            getCategoryList();
        }
    ]);
})();