(function (global) {

    'use strict';

    utilities.directive('cstModal', function () {
        return {
            required: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.on('click', function () {
                    var modalId = '#' + attrs.cstModal;
                    $(modalId).modal('show');
                });
            }
        };
    });

}(window));

