(function () {
    angular.module('app').controller('app.views.company.index', [
        '$scope','$state', '$uibModal', 'abp.services.app.company',
        function ($scope, $state, $uibModal, companyService) {
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

            vm.delete = function (model) {
                abp.message.confirm(
                    "是否删除企业 '" + model.companyName + "'，以及相关企业认证信息?",
                    function (result) {
                        if (result) {
                            companyService.deleteCompany({ id: model.id })
                                .then(function () {
                                    abp.notify.info("已删除企业: " + category.categoryName);
                                    getCompanyList();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getCompanyList();
            };

            vm.goToCompanyDetail = function (companyId) {
                $state.go("editCompany", { id: companyId});
                //$location.path(path);
            };


            getCompanyList();
        }
    ]);
})();