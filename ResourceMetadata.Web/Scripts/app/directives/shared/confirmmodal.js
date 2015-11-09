(function (global) {

    'use strict';

    utilities.directive("cstConfirmModal", ['$modal','$rootScope', function ($modal, $rootScope) {
        return {
            restrict: "A",
            scope: {
                approve: '&onApprove',
                deny: '&onDeny',
                closable: '=closable',
                id: '@modalId',
                title: '@title',
                message: '@message'
            },
            templateUrl: "/Scripts/app/partials/confirm-modal.html",
            link: function (scope, element, attrs, ngModelCtrl) {


                function showModal () {
                    scope.modalInstance = $modal.open({
                        templateUrl: 'myModalContent.html',
                        scope: scope
                    });
                }
                scope.closeModal = function () {
                    scope.modalInstance.close();
                };

                var removeShowModalListener =  $rootScope.$on('Modal.Show', showModal);

                element.on('click',showModal);

                scope.$on('$destroy', function() {
                    removeShowModalListener();
                });
            }
        };
    }]);

}(window));

