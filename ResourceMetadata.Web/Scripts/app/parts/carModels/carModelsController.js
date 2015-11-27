(function (global) {

    'use strict';

    app.controller('CarModelsCtrl', ['$scope', 'ngTableParams', 'carModelService',
        function ($scope, ngTableParams, carModelService) {
            carModelService.getAll().then(function (response) {
                $scope.tableParams = new ngTableParams({
                    count: 10,
                    page: 1
                }, {
                    filterDelay: 300,
                    data: response.data
                });
            });

            $scope.deleteCarModel = function (carModelId) {
                carModelService.deleteById(carModelId).then(function (response) {
                    carModelService.getAll().then(function (response) {
                        $scope.tableParams = new ngTableParams({
                            count: 10,
                            page: 1
                        }, {
                            filterDelay: 300,
                            data: response.data
                        });
                        $scope.tableParams.reload();
                    });
                });
            };
        }]);

}(window));

