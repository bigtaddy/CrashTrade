/**
 * Created by a.kravtsov on 5/29/2015.
 */

(function (global) {

    'use strict';

    utilities.directive('progressBar', function () {
        return {
            restrict: 'E',
            scope: {
                percent: "="
            },
            template: '<div class="ui teal progress" data-percent="{{percent}}" id="example1">' +
            '<div class="bar"></div>' +
            '<div class="label">{{percent}} Funded</div>' +
            '</div>',
            link: function (scope, element, attrs, ngModelCtrl) {
                $('#example1').progress();
            }
        };
    });

}(window));

