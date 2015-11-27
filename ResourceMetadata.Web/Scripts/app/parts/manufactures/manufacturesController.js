(function (global) {

    'use strict';

    app.controller('ManufacturesCtrl', ['$scope', 'ngTableParams', 'manufactureService',
        function ($scope, ngTableParams, manufactureService) {
            manufactureService.getAll().then(function (response) {
                $scope.tableParams = new ngTableParams({
                    count: 10,
                    page: 1
                }, {
                    filterDelay: 300,
                    data: response.data
                });
            });

            $scope.deleteManufacture = function (manufactureId) {
                manufactureService.deleteById(manufactureId).then(function (data, responseHeaders) {
                    manufactureService.getAll().then(function (response) {
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

