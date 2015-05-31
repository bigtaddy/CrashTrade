(function (global) {

    'use strict';

    utilities.directive("cstConfirmModal", ['$modal', function ($modal) {
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

                scope.closeModal = function () {
                    scope.modalInstance.close();
                };

                element.on('click', function (e) {
                    scope.modalInstance = $modal.open({
                        templateUrl: 'myModalContent.html',
                        scope: scope
                    });
                });
            }
        };
    }]);

}(window));

