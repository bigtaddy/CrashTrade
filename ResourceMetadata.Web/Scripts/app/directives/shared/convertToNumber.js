/**
 * Created by a.kravtsov on 11/25/2015.
 */

(function (global) {
    'use strict';
    utilities.directive('convertToNumber', function() {
            return {
                require: 'ngModel',
                link: function(scope, element, attrs, ngModel) {
                    ngModel.$parsers.push(function(val) {
                        return parseInt(val, 10);
                    });
                    ngModel.$formatters.push(function(val) {
                        return '' + val;
                    });
                }
            };
        });
})(window.angular);