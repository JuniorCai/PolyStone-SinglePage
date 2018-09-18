(function () {
    angular.module('app').controller('app.views.region.index', [
        '$scope', 'abp.services.app.region',
        function ($scope, regionService) {
            var vm = this;

            vm.provinceList = [];
            vm.cityList = [];
            vm.areaList = [];

            function getRegionList(code,type) {
                regionService.getPagedRegions({
                    regionCode: code,
                    sorting: "id"
                }).then(function (result) {
                    if (type == "province") {
                        vm.provinceList = result.data.items;
                    } else if (type == "city") {
                        vm.cityList = result.data.items;
                    } else {
                        vm.areaList = result.data.items;
                    }
                });
            }


            vm.openRegionEditModal = function (region) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/region/editModal.cshtml',
                    controller: 'app.views.region.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return region.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getRegionList();
                });
            };

            vm.delete = function(region) {
                abp.message.confirm(
                    "是否删除产品类别 '" + region.regionName + "'?",
                    function(result) {
                        if (result) {
                            regionService.deleteCategory({ id: category.id })
                                .then(function() {
                                    abp.notify.info("已删除产品类别: " + region.regionName);
                                    getRegionList();
                                });
                        }
                    });
            };

            vm.refresh = function () {
                getRegionList("", "province");
            };

            getRegionList("","province");
        }
    ]);
})();