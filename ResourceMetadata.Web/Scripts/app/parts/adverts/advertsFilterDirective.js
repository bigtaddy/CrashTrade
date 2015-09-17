/**
 * Created by a.kravtsov on 9/16/2015.
 */

(function (global) {

    'use strict';

    utilities.directive('advertsFilterOptions', ['entityService', function (entityService) {
        return {
            restrict: 'E',
            templateUrl: "/Scripts/app/parts/adverts/advertsFilterOptionsDirective.html",
            scope: {
                getFilterOptions: "=",
                shouldBeFiltered: "="
            },
            link: function (scope, element, attrs) {
                scope.filterOptions = "true";

                /**
                 * getFilterOptions
                 * @returns {string|string|*|filterOptions}
                 */
                scope.getFilterOptions = function () {
                    return scope.filterOptions
                }

                /**
                 * UpdateFilterOptions handler
                 */
                scope.$on('UpdateFilterOptions', function (event, args) {
                    var filterOptions = "";

                    if (scope.yearFrom && scope.yearTo) {
                        if (scope.yearFrom > scope.yearTo) {
                            var tmp = scope.yearFrom;
                            scope.yearFrom = scope.yearTo;
                            scope.yearTo = tmp;
                        }
                    }

                    if (scope.yearFrom) {
                        filterOptions += getOption(filterOptions, "Year >= " + scope.yearFrom)
                    }

                    if (scope.yearTo) {
                        filterOptions += getOption(filterOptions, "Year <= " + scope.yearTo)
                    }

                    if (filterOptions == "") {
                        scope.filterOptions = "true";
                    } else {
                        scope.filterOptions = filterOptions;
                    }
                });

                /**
                 * ClearFilter handler
                 */
                scope.$on('ClearFilter', function (event, args) {
                    scope.filterOptions = "true";
                })
            }
        };

        /**
         * getOption
         * @param filterOptions
         * @param option
         * @returns {*}
         */
        function getOption(filterOptions, option) {
            if (filterOptions == "") {
                return option;
            } else {
                return " and " + option;
            }
        }

    }]);

}(window));