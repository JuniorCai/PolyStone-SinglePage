(function () {
    angular.module('app').controller('app.views.company.createContactModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.contact',
        function ($scope, $uibModalInstance, contactService) {
            var vm = this;

            vm.category = {
                isActive: true,
                isShow: true,
                isDeleted:false
            };

            vm.roles = [];


            vm.save = function () {
                
                contactService.createCategory(vm.category)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

           // getRoles();
        }
    ]);
})();