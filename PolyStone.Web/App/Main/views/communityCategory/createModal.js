(function () {
    angular.module('app').controller('app.views.communityCategory.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.communityCategory',
        function ($scope, $uibModalInstance, communityCategoryService) {
            var vm = this;

            vm.category = {
                isActive: true,
                isShow: true,
                isDeleted:false
            };

            vm.save = function () {
                
                communityCategoryService.createCommunityCategory(vm.category)
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