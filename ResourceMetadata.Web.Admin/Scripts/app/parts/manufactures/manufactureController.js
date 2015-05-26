(function (global) {

    'use strict';

    app.controller('ManufactureCtrl', ['$scope', '$location', '$routeParams', 'manufactureService',
        function ($scope, $location, $routeParams, manufactureService) {
            $scope.addManufacture = function (location) {
                manufactureService.add(location)
                    .then(function (response) {
                        $location.url('/Manufactures');
                    });
            };
            $scope.editManufacture = function (manufacture) {
                manufactureService.edit(manufacture).then(function (response) {
                    $location.url('/Manufactures');
                });
            };

            init();
            function init() {
                if ($routeParams.manufactureId > 0) {
                    manufactureService.getById($routeParams.manufactureId).then(function (response) {
                        $scope.manufacture = response.data;
                    });
                }
            }
        }]);

}(window));


