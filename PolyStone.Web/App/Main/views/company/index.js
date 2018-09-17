(function () {
    angular.module('app').controller('app.views.company.index', [
        '$scope', '$uibModal', 'abp.services.app.company',
        function ($scope, $uibModal, companyService) {
            var vm = this;

            vm.companyList = [];

            function getCompanyList() {
                companyService.getPagedCompanys({
                    filterText: "",
                    sorting: "CreationTime"
                }).then(function (result) {
                    vm.companyList = result.data.items;
                });
            }

            vm.delete = function (category) {
                abp.message.confirm(
                    "是否删除产品类别 '" + category.categoryName + "'?",
                    function (result) {
                        if (result) {
                            companyService.deleteCategory({ id: category.id })
                                .then(function () {
                                    abp.notify.info("已删除产品类别: " + category.categoryName);
                                    getCompanyList();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getCompanyList();
            };

            getCompanyList();
        }
    ]);
})();