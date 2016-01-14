(function (global) {

    'use strict';

    app.controller('UserManagementCtrl', ['$scope', 'ngTableParams', 'entityService', 'accountService',
        function ($scope, ngTableParams, entityService, accountService) {
            entityService.get('Account/GetUsers').then(function (response) {
                createTableParams(response.data);
            });

            $scope.deleteUser = function (id) {
                accountService.deleteUser(id).then(function (data, responseHeaders) {
                    entityService.get('Account/GetUsers').then(function (response) {
                        createTableParams(response.data);
                    });
                });
            };

            $scope.changePremiumStatus = function (id) {
                accountService.changePremiumStatus(id).then(function (data, responseHeaders) {
                    entityService.get('Account/GetUsers').then(function (response) {
                        createTableParams(response.data);
                    });
                });
            };

            /**
             * createTableParams
             * @param data
             */
            function createTableParams(data){
                $scope.tableParams = new ngTableParams({
                    count: 10,
                    page: 1
                }, {
                    filterDelay: 300,
                    data: data
                });
                $scope.tableParams.reload();
            }
        }]);

}(window));

