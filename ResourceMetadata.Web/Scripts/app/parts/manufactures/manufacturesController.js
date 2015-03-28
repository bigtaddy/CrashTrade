(function (global) {

    'use strict';

    app.controller('ManufacturesCtrl', ['$scope', 'ngTableParams', 'manufactureService',
        function ($scope, ngTableParams, manufactureService) {
            $scope.tableParams = new ngTableParams({
                total: 1,
                page: 1
            }, {
                counts: [],
                getData: function ($defer, params) {
                    manufactureService.getAll().then(function (response) {
                        $defer.resolve(response.data);
                    });
                }
            });

            $scope.deleteManufacture = function (manufactureId) {
                manufactureService.deleteById(manufactureId).then(function (data, responseHeaders) {
                        $scope.tableParams.reload();
                    });
            };
        }]);

}(window));

