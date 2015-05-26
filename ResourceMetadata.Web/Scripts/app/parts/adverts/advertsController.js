(function (global) {

    'use strict';

    app.controller('AdvertsCtrl', ['$scope', 'ngTableParams', 'entityService', 'advertService','$routeParams','$location',
        function ($scope, ngTableParams, entityService, advertService, $routeParams, $location) {

            $scope.advertType = $routeParams.advertType;
            if(advertService.getCodeOfAdvertType($scope.advertType) == false){
                $location.url('/Home');
            }

            $scope.tableParams = new ngTableParams({
                total: 1,
                page: 1
            }, {
                counts: [],
                getData: function ($defer, params) {
                    advertService.getAll($scope.advertType).then(function (response) {
                        $defer.resolve(response.data);
                    });
                }
            });

            $scope.deleteAdvert = function (advertId) {
                entityService.deleteById(advertId, "Adverts").then(function (response) {
                        $scope.tableParams.reload();
                    });
            };
        }]);

}(window));

