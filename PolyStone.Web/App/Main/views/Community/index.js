(function () {
    angular.module('app').controller('app.views.community.index', [
        '$scope','$location','$state', 'abp.services.app.community', 'abp.services.app.communityCategory',
        function ($scope, $location, $state, communityService, communityCategory) {
            var vm = this;

            vm.categoryList = [];

            vm.communityList = [];

            $scope.selectedCategory = "-1";
            $scope.selectedVerify = "-1";
            $scope.selectedRelease = "-1";


            //Pagination Config
            $scope.maxPageNumber = 6;
            //$scope.totalItems = 0;
            //每页显示条数(默认10条)
            $scope.pageSize =2;

            $scope.pageIndex = 1;
            $scope.param = {};
            $scope.data = {}; // 参数
            $scope.data.param = $scope.param;



            //Pagination Config End

            function getCategoryList() {
                communityCategory.getPagedCommunityCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.categoryList = result.data.items;
                });
            }


            vm.getCommunityList = function (page) {
                var searchParams = {};

                communityService.getPagedCommunitys
                ({
                    filterText: "",
                    maxResultCount: $scope.pageSize,
                    skipCount: (page - 1) * $scope.pageSize,
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.communityList = result.data.items;
                    $scope.totalItems = result.data.totalCount;
                });
            };

            vm.gotoDetail = function(itemId) {
                $state.go("communityEdit", { id: itemId });
            };


            vm.delete = function (community) {
                abp.message.confirm(
                    "是否删除产品类别 '" + community.title + "'?",
                    function(result) {
                        if (result) {
                            communityService.deleteCommunity({ id: community.id })
                                .then(function() {
                                    abp.notify.info("已删除产品类别: " + community.title);
                                    getCommunityList();
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getCommunityList();
            };

            vm.getCommunityList($scope.pageIndex);
            getCategoryList();
        }
    ]);
})();