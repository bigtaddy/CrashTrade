(function (global) {

    'use strict';

    app.controller('CarModelCtrl', ['$scope', '$location', '$routeParams', 'carModelService', 'manufactureService',
        function ($scope, $location, $routeParams, carModelService, manufactureService) {
            $scope.carModel = {};
            $scope.manufactures = [];

            $scope.addCarModel = function (location) {
                carModelService.add(location)
                    .then(function (data) {
                        $location.url('/CarModels');
                    });
            };
            $scope.editCarModel = function (carModel) {
                carModelService.edit(carModel)
                    .then(function (data) {
                        $location.url('/CarModels');
                    });
            };

            init();
            function init() {
                if ($routeParams.carModelId > 0) {
                    carModelService.getById($routeParams.carModelId).then(function (response) {
                        $scope.carModel = response.data;
                    });
                }
                manufactureService.getAll().then(function (response) {
                    $scope.manufactures = response.data;
                });
            }
        }]);

}(window));


