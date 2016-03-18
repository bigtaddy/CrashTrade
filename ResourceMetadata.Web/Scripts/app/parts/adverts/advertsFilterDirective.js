/**
 * Created by a.kravtsov on 9/16/2015.
 */

(function (global) {

    'use strict';

    utilities.directive('advertsFilterOptions', ['entityService', 'manufactureService', '$route', function (entityService, manufactureService, $routeParams) {
        return {
            restrict: 'E',
            templateUrl: "/Scripts/app/parts/adverts/advertsFilterOptionsDirective.html",
            scope: {
                getFilterOptions: "=",
                shouldBeFiltered: "=",
                advertType: "=?"
            },
            link: function (scope, element, attrs) {

                addDropDownLogicAndGetData(scope);
                scope.filterOptions = "true";
                scope.car = {};

                addHandlersAndWatchers(scope);
                scope.advertType = $routeParams.current.data.advertType;


                scope.$on('ClearFilter', function(){
                    scope.car = {};
                });

                /**
                 * getFilterOptions
                 * @returns {string|string|*|filterOptions}
                 */
                scope.getFilterOptions = function () {
                    return scope.filterOptions
                };


            }
        };

        /**
         * addHandlersAndWatchers
         * @param scope
         */
        function addHandlersAndWatchers(scope){
            /**
             * UpdateFilterOptions handler
             */
            scope.$on('UpdateFilterOptions', function (event, args) {
                var filterOptions = "";

                filterOptions += getOption(filterOptions,generateFromToFilterOptions(scope.car.yearFrom, scope.car.yearTo, "Year"));
                filterOptions += getOption(filterOptions,generateFromToFilterOptions(scope.car.priceFrom, scope.car.priceTo, "Price"));

                filterOptions += getOption(filterOptions,generateSimpleOption(scope.car.manufactureId, "ManufactureId"));
                filterOptions += getOption(filterOptions,generateSimpleOption(scope.car.carModelId, "CarModelId"));
                filterOptions += getOption(filterOptions,generateSimpleOption(scope.car.transmissionType, "TransmissionType"));
                filterOptions += getOption(filterOptions,generateSimpleOption(scope.car.fuelType, "FuelType"));

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

        /**
         * generateFromToFilterOptions
         * @param fromValue
         * @param toValue
         * @param propertyName
         * @returns {string}
         */
        function generateFromToFilterOptions(fromValue, toValue, propertyName) {
            var filterOptions = "";

            if (fromValue && toValue) {
                if (fromValue > toValue) {
                    var tmp = fromValue;
                    fromValue = toValue;
                    toValue = tmp;
                }
            }

            if (fromValue) {
                filterOptions += getOption(filterOptions, propertyName + " >= " + fromValue)
            }

            if (toValue) {
                filterOptions += getOption(filterOptions, propertyName + " <= " + toValue)
            }

            return filterOptions;
        }

        /**
         * generateSimpleOption
         * @param value
         * @param propertyName
         */
        function generateSimpleOption(value, propertyName){
            if(value){
                return propertyName + "=" +  value;
            }

            return "";
        }

        /**
         * getOption
         * @param filterOptions
         * @param option
         * @returns {*}
         */
        function getOption(filterOptions, option) {
            if (filterOptions == "" || option == "") {
                return option;
            } else {
                return " and " + option;
            }
        }

        /**
         * getDropDownDataData
         */
        function addDropDownLogicAndGetData($scope) {
            manufactureService.getAll().then(function (response) {
                $scope.manufactures = response.data;
            });

            $scope.$watch('car.manufactureId', function (newValue, oldValue) {
                if (newValue != oldValue) {
                    setCarModelsArrayByManufactureId(newValue, $scope);
                }
            });

            $scope.CrashTradeSettings = CrashTradeSettings;
        }

        /**
         * setCarModelsByManufactureId
         * @param manufactureId
         * @param $scope
         */
        function setCarModelsArrayByManufactureId(manufactureId, $scope) {
            $scope.car.carModelId = null;
            for (var i = 0; i < $scope.manufactures.length; i++) {
                if ($scope.manufactures[i].Id == manufactureId) {
                    $scope.carModels = $scope.manufactures[i].CarModels;
                    break;
                }
            }
        }

    }]);

}(window));