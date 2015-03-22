(function (global) {

    'use strict';

    app.controller('ManufactureCtrl', ['$scope', '$location', '$routeParams', 'manufactureService',
        function ($scope, $location, $routeParams, manufactureService) {
            $scope.addManufacture = function (location) {
                manufactureService.add(location).$promise
                    .then(function (data) {
                        $location.url('/Manufactures');
                    });
            };
            $scope.editManufacture = function (manufacture) {
                manufactureService.edit(manufacture).$promise.then(function (data) {
                    $location.url('/Manufactures');
                });
            };

            init();
            function init() {
                if ($routeParams.manufactureId > 0) {
                    $scope.manufacture = manufactureService.getById($routeParams.manufactureId);
                }
            }
        }]);

}(window));


