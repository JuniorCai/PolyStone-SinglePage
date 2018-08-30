(function () {
    angular.module('app').controller('app.views.communityCategory.index', [
        '$scope', '$uibModal', 'abp.services.app.communityCategory',
        function ($scope, $uibModal, communityCategoryService) {
            var vm = this;

            vm.categoryList = [];

            function getCategoryList() {
                communityCategoryService.getPagedCommunityCategorys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.categoryList = result.data.items;
                });
            }

            vm.openCommunityCategoryCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/communityCategory/createModal.cshtml',
                    controller: 'app.views.communityCategory.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getCategoryList();
                });
            };

            vm.openCommunityCategoryEditModal = function (category) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/communityCategory/editModal.cshtml',
                    controller: 'app.views.communityCategory.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return category.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getCategoryList();
                });
            };

            vm.delete = function (category) {
                abp.message.confirm(
                    "是否删除圈子类别 '" + category.categoryName + "'?",
                    function (result) {
                        if (result) {
                            communityCategoryService.deleteCommunityCategory({ id: category.id })
                                .then(function () {
                                    abp.notify.info("已删除圈子类别: " + category.categoryName);
                                    getCategoryList();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getCategoryList();
            };

            getCategoryList();
        }
    ]);
})();