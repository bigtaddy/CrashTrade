
app.controller('ManufacturesCtrl', ['$scope', 'ngTableParams', 'manufactureService',
    function ($scope, ngTableParams, manufactureService) {
        $scope.tableParams = new ngTableParams({
            total: 1,
            page: 1
        }, {
            counts: [],
            getData: function ($defer, params) {
                manufactureService.getAll().$promise.then(function (manufactures) {
                    $defer.resolve(manufactures);
                });
            }
        });

        $scope.deleteManufacture = function (manufactureId) {
            manufactureService.deleteById(manufactureId).$promise
                .then(function (data, responseHeaders) {
                    $scope.tableParams.reload();
                });
        };
    }]);