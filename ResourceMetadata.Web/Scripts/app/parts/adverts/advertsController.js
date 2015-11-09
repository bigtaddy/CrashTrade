(function (global) {

    'use strict';

    app.controller('AdvertsCtrl', ['$scope', 'ngTableParams', 'entityService', 'advertService', '$routeParams', '$location', '$timeout', '$rootScope',
        function ($scope, ngTableParams, entityService, advertService, $routeParams, $location, $timeout, $rootScope) {

            getAndValidateAdvertType();

            /**
             * deleteAdvert
             * @param advertId
             */
            $scope.deleteAdvert = function (advertId) {
                entityService.deleteById(advertId, "Adverts").then(function (response) {
                    $scope.pageChangeHandler($scope.currentPage);
                });
            };

            /**
             * pageChangeHandler
             * @param num
             */
            $scope.pageChangeHandler = function (num) {
                $scope.currentPage = num;

                var filterOptions = $scope.getFilterOptions ? $scope.getFilterOptions() : "true";

                advertService.getAll($scope.advertType, $scope.currentPage, $scope.pageSize, $scope.sortOptions, filterOptions).then(function (response) {
                    $scope.adverts = response.data.adverts;
                    $timeout(function () {
                        $('.text-new-line').trunk8({
                            lines: 5
                        });
                    }, 0);
                    $scope.count = response.data.count;
                });
            };

            /**
             * pageSizeWasChanged
             * @param newValue
             * @param oldValue
             */
            var pageSizeWasChanged = function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }
                $scope.pageChangeHandler($scope.currentPage);

            };

            /**
             * sortOptions chacge handler
             */
            $scope.$watch('sortOptions', function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }

                $scope.pageChangeHandler(1);
            });

            /**
             * filter
             */
            $scope.filter = function () {
                $rootScope.$broadcast('UpdateFilterOptions');
                $scope.pageChangeHandler(1);
            };

            /**
             * clearFilter
             */
            $scope.clearFilter = function () {
                $rootScope.$broadcast('ClearFilter');
                $scope.pageChangeHandler(1);
            };

            /**
             * getAndValidateAdvertType
             */
            function getAndValidateAdvertType(){
                $scope.advertType = $routeParams.advertType;
                if (advertService.validateAdvertType($scope.advertType) == false && $scope.advertType != undefined && $scope.advertType != "My") {
                    $location.url('/Home');
                }
            }

            $scope.adverts = {};
            $scope.sortOptions = 'CreatedOn descending';
            $scope.pageSize = 10;
            $scope.totalAdverts = 0;
            $scope.$watch('pageSize', pageSizeWasChanged);
            $scope.pageChangeHandler(1);

        }]);

}(window));

