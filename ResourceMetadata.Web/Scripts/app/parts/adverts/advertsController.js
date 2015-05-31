(function (global) {

    'use strict';

    app.controller('AdvertsCtrl', ['$scope', 'ngTableParams', 'entityService', 'advertService', '$routeParams', '$location',
        function ($scope, ngTableParams, entityService, advertService, $routeParams, $location) {



            $scope.advertType = $routeParams.advertType;
            if (advertService.getCodeOfAdvertType($scope.advertType) == false) {
                $location.url('/Home');
            }

            $scope.deleteAdvert = function (advertId) {
                entityService.deleteById(advertId, "Adverts").then(function (response) {
                    $scope.tableParams.reload();
                });
            };

            $scope.pageChangeHandler = function (num) {
                $scope.currentPage = num;
                $scope.adverts = {};
                advertService.getAll($scope.advertType, $scope.currentPage, $scope.pageSize).then(function (response) {
                    $scope.adverts = response.data.adverts;
                    $scope.count = response.data.count;
                });
            };

            var pageSizeWasChanged = function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }
                $scope.pageChangeHandler($scope.currentPage);

            };

            $scope.pageSize = 10;
            $scope.totalAdverts = 0;
            $scope.$watch('pageSize', pageSizeWasChanged);
            $scope.pageChangeHandler(1);

        }]);

}(window));

