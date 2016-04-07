(function (global) {

    'use strict';

    app.controller('AdvertsCtrl', ['$scope', 'ngTableParams', 'entityService', 'advertService', '$location', '$timeout', '$rootScope', '$route',
        function ($scope, ngTableParams, entityService, advertService, $location, $timeout, $rootScope,$route) {
            $scope.advertType = $route.current.data.advertType;
            $scope.adverts = {};
            $scope.sortOptions = 'CreatedOn descending';
            $scope.pageSize = 10;
            $scope.totalAdverts = 0;

            $timeout(function() {
                $scope.$watch('pageSize', pageSizeWasChanged);
                $scope.pageChangeHandler(1);
            });

            /**
             * deleteAdvert
             * @param advertId
             */
            $scope.deleteAdvert = function (advertId) {
                entityService.deleteById(advertId, "Adverts/Delete").then(function (response) {
                    $scope.pageChangeHandler($scope.currentPage);
                });
            };

            /**
             * pageChangeHandler
             * @param num
             */
            $scope.pageChangeHandler = function (num) {
                $scope.adverts = [];
                $scope.currentPage = num;
                $scope.scrollTop();

                var filterOptions = $scope.getFilterOptions ? $scope.getFilterOptions() : "true";

                advertService.getAll($scope.advertType, $scope.currentPage, $scope.pageSize, $scope.sortOptions, filterOptions).then(function (response) {
                    $scope.adverts = response.data.adverts;
                    $scope.count = response.data.count;
                });
            };

            /**
             * pageSizeWasChanged
             * @param newValue
             * @param oldValue
             */
            function pageSizeWasChanged(newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }
                $scope.pageChangeHandler($scope.currentPage);
            };

            /**
             * sortOptions chacge handler
             */
            //$scope.$watch('sortOptions', function (newValue, oldValue) {
            //    if (newValue === oldValue) {
            //        return;
            //    }
            //
            //    $scope.pageChangeHandler(1);
            //});

            /**
             * filter
             */
            $scope.filter = function () {
                $rootScope.$broadcast('UpdateFilterOptions');
                $scope.pageChangeHandler(1);
                $timeout(function() {
                    $scope.showSettingsOnMobile = false;
                    $scope.scrollTop();
                })
            };

            /**
             * clearFilter
             */
            $scope.clearFilter = function () {
                $rootScope.$broadcast('ClearFilter');
                $scope.pageChangeHandler(1);
                $timeout(function() {
                    $scope.showSettingsOnMobile = false;
                    $scope.scrollTop();
                })
            };

            /**
             * pageChanged
             */
            $scope.pageChanged = function() {
                $scope.pageChangeHandler($scope.currentPage);
            };
        }]);

}(window));

