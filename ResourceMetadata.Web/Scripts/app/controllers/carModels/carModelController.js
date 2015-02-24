app.controller('CarModelCtrl', ['$scope', '$location', '$routeParams', 'carModelService',
    function ($scope, $location, $routeParams, carModelService) {
        $scope.addCarModel = function (location) {
            carModelService.add(location).$promise
                .then(function (data) {
                    $location.url('/CarModels');
                });
        };
        $scope.editCarModel = function (carModel) {
            carModelService.edit(carModel).$promise.then(function (data) {
                $location.url('/CarModels');
            });
        };

        init();
        function init() {
            if ($routeParams.carModelId > 0) {
                $scope.carModel = carModelService.getById($routeParams.carModelId);
            }
        }
    }]);