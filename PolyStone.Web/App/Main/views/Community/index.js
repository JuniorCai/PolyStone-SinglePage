(function () {
    angular.module('app').controller('app.views.community.index', [
        '$scope','$location','$state', 'abp.services.app.community', 'abp.services.app.communityCategory',
        function ($scope, $location, $state, communityService, communityCategory) {
            var vm = this;

            vm.categoryList = [];

            vm.communityList = [];
           


            //Pagination Config
            $scope.maxPageNumber = 6;
            $scope.totalItems = 0;
            //每页显示条数(默认10条)
            $scope.pageSize =2;

            $scope.pageIndex = 1;



            //Pagination Config End
            function initParams() {
                vm.search = {
                    communityId: 0,
                    title: "",
                    userId: 0,
                    fromDate: "",
                    endDate: ""
                };

                $scope.selectedCategory = "-1";
                $scope.selectedVerify = "-1";
                $scope.selectedRelease = "-1";
            }


            function initPickers() {
                //init date pickers
                $('.date-picker').datepicker({
                    rtl: false,
                    autoclose: true,
                    language: 'zh-CN',
                    pickerPosition: 'top-right',
                    format: 'yyyy-mm-dd'
                });
            }


            function getCategoryList() {
                communityCategory.getPagedCommunityCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function(result) {
                    vm.categoryList = result.data.items;
                });
            }

            vm.resetSearch = function() {
                initParams();
            };

            vm.getCommunityList = function(page) {
                var searchParams = {
                    id: vm.search.communityId,
                    title: vm.search.title,
                    communityCategoryId: $scope.selectedCategory,
                    userId: vm.search.userId,
                    verifyStatus: $scope.selectedVerify,
                    releaseStatus: $scope.selectedRelease,
                    fromTime: vm.search.fromDate,
                    endTime: vm.search.endDate,
                    sorting: "CreationTime",
                    maxResultCount: $scope.pageSize,
                    skipCount: (page - 1) * $scope.pageSize,
                };

                communityService.getPagedCommunitys
                    (searchParams).then(function(result) {
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

            initPickers();
            initParams();
            vm.getCommunityList($scope.pageIndex);
            getCategoryList();
        }
    ]);
})();