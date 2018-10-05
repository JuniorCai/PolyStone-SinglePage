(function () {
    angular.module('app').controller('app.views.company.createContactModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.contact','companyId','id',
        function ($scope, $uibModalInstance, contactService,companyId,id) {
            var vm = this;

            vm.contact = {
                id: id,
                companyId: companyId,
                linkMan: "",
                phone: "",
                tel: "",
                email: "",
                isDefault: false,
                isDeleted: false
            };

            function initContact() {
                if (id > 0) {
                    contactService.getContactById({ id: id }).then(function(result) {
                        if (result.data == null) {
                            abp.notify.error("未找到相应联系人信息");
                            return;
                        } else {
                            vm.contact = result.data;
                        }
                    });
                }
            }


            vm.save = function () {
                contactService.createOrUpdateContact({
                        contactEditDto: vm.contact
                    })
                    .then(function() {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            initContact();
        }
    ]);
})();