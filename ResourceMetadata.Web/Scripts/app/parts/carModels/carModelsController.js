(function (global) {

    'use strict';

    app.controller('CarModelsCtrl', ['$scope', 'ngTableParams', 'carModelService',
        function ($scope, ngTableParams, carModelService) {
            $scope.tableParams = new ngTableParams({
                total: 1,
                page: 1
            }, {
                counts: [],
                getData: function ($defer, params) {
                    carModelService.getAll().then(function (response) {
                        $defer.resolve(response.data);
                    });
                }
            });

            $scope.deleteCarModel = function (carModelId) {
                carModelService.deleteById(carModelId).then(function (response) {
                        $scope.tableParams.reload();
                    });
            };
        }]);

}(window));

