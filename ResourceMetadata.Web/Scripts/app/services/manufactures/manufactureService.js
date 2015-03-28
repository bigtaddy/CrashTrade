(function (global) {

    'use strict';

    app.factory('manufactureService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var add = function (manufacture) {
            return $http({
                method: 'POST',
                url: baseUrl + 'Manufactures',
                data: manufacture
            });
        };
        var edit = function (manufacture) {
            return $http({
                method: 'PUT',
                url: baseUrl + 'Manufactures/' + manufacture.Id,
                data: manufacture
            });
        };
        var getById = function (manufactureId) {
            return $http({
                method: 'GET',
                url: baseUrl + 'Manufactures/' + manufactureId
            });
        };
        var getAll = function () {
            return $http({
                method: 'GET',
                url: baseUrl + 'Manufactures'
            });
        };
        var deleteById = function (manufactureId) {
            return $http({
                method: 'DELETE',
                url: baseUrl + 'Manufactures/' + manufactureId
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
