
app.controller('CarModelsCtrl', ['$scope', 'ngTableParams', 'carModelService',
    function ($scope, ngTableParams, carModelService) {
        $scope.tableParams = new ngTableParams({
            total: 1,
            page: 1
        }, {
            counts: [],
            getData: function ($defer, params) {
                carModelService.getAll().$promise.then(function (carModels) {
                    $defer.resolve(carModels);
                });
            }
        });

        $scope.deleteCarModel = function (carModelId) {
            carModelService.delete(carModelId).$promise
                .then(function (data, responseHeaders) {
                    $scope.tableParams.reload();
                });
        };
    }]);