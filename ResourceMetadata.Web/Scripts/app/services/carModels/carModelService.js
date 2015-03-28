(function (global) {

    'use strict';

    app.factory('carModelService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var add = function (carModel) {
            return $http({
                method: 'POST',
                url: baseUrl + 'CarModels',
                data: carModel
            });
        };
        var edit = function (carModel) {
            return $http({
                method: 'PUT',
                url: baseUrl + 'CarModels/' + carModel.Id,
                data: carModel
            });
        };
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
        var deleteById = function (carModelId) {
            return $http({
                method: 'DELETE',
                url: baseUrl + 'CarModels/' + carModelId
            });
        };

        return {
            add: add,
            edit: edit,
            getById: getById,
            getAll: getAll,
            deleteById: deleteById
        };
    }]);

}(window));


