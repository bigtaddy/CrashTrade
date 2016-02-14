(function (global) {

    'use strict';

    utilities.directive("cstConfirmModal", ['$rootScope', '$uibModal', function ($rootScope, $uibModal) {
        return {
            restrict: "A",
            scope: {
                approve: '&onApprove',
                onDeny: '&onDeny',
                closable: '=closable',
                id: '@modalId',
                title: '@title',
                message: '@message',
                linkText: '@linkText'
            },
            templateUrl: "/Scripts/app/partials/confirm-modal.html",
            link: function (scope, element) {
                if(!scope.linkText){
                    scope.linkText = 'Удалить'
                }

                function showModal() {
                    scope.modalInstance = $uibModal.open({
                        templateUrl: 'myModalContent.html',
                        scope: scope,
                        controller: function () {
                        }
                    });
                }

                scope.closeModal = function () {
                    scope.modalInstance.close();
                };

                scope.deny = function () {
                    if (scope.onDeny) {
                        scope.onDeny();
                    }
                }

                element.on('click', showModal);

            }
        };
    }]);
}(window));

