(function (global) {

    'use strict';

    app.factory('carModelService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;


        var getById = function (carModelId) {
            return $http({
                method: 'GET',
                url: baseUrl + 'CarModels/' + carModelId
            });
        };
        var getAll = function () {
            return $http({
                method: 'GET',
                url: baseUrl + 'CarModels'
            });
        };


        return {
            getById: getById,
            getAll: getAll
        };
    }]);

}(window));


