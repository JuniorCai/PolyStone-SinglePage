(function () {
    angular.module('app').controller('app.views.communityCategory.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.communityCategory', 'id',
        function ($scope, $uibModalInstance, categoryService, id) {
            var vm = this;

            vm.category = {
                isActive: true
            };


            var init = function() {
                categoryService.getCommunityCategoryById({ id: id })
                    .then(function(result) {
                        vm.category = result.data;
                    });
            };

            vm.save = function () {
               
                categoryService.updateCommunityCategory(vm.category)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            init();
        }
    ]);
})();