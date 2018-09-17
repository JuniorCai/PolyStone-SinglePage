(function () {
    angular.module('app').controller('app.views.region.index', [
        '$scope', '$uibModal', 'abp.services.app.region',
        function ($scope, $uibModal, regionService) {
            var vm = this;

            vm.regionList = [];

            function getRegionList() {
                regionService.getPagedRegions({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.regionList = result.data.items;
                });
            }

            vm.openRegionCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/region/createModal.cshtml',
                    controller: 'app.views.region.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getRegionList();
                });
            };

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
                getRegionList();
            };

            getRegionList();
        }
    ]);
})();