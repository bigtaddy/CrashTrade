(function (global) {

    'use strict';

    app.controller('SparePartAdvertsCtrl', ['$scope', 'ngTableParams', 'entityService', 'advertService', '$routeParams', '$location', '$timeout', '$rootScope',
        function ($scope, ngTableParams, entityService, advertService, $routeParams, $location, $timeout, $rootScope) {

            /**
             * deleteAdvert
             * @param advertId
             */
            $scope.deleteAdvert = function (advertId) {
                entityService.deleteById(advertId, "SparePartAdverts").then(function (response) {
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

                entityService.getAll('SparePartAdverts', {
                    pageNumber: $scope.currentPage,
                    itemsPerPage: $scope.pageSize,
                    sortOptions: $scope.sortOptions,
                    filterOptions: filterOptions
                }).then(function (response) {
                    $scope.adverts = response.data.adverts;
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

            $scope.pageChanged = function () {
                $scope.pageChangeHandler($scope.currentPage);
            };

            $scope.adverts = {};
            $scope.sortOptions = 'CreatedOn descending';
            $scope.pageSize = 10;
            $scope.totalAdverts = 0;
            $scope.$watch('pageSize', pageSizeWasChanged);
            $scope.pageChangeHandler(1);
        }]);

}(window));

