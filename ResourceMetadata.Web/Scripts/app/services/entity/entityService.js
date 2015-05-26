/**
 * Created by a.kravtsov on 5/23/2015.
 */
(function (global) {

    'use strict';

    app.factory('entityService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var add = function (model, modelName) {
            return $http({
                method: 'POST',
                url: baseUrl + modelName,
                data: model
            });
        };
        var edit = function (model, modelName) {
            return $http({
                method: 'PUT',
                url: baseUrl + modelName+ "/" + model.Id,
                data: model
            });
        };
        var getById = function (modelId, modelName) {
            return $http({
                method: 'GET',
                url: baseUrl + modelName + "/" + modelId
            });
        };
        var getAll = function (modelName) {
            return $http({
                method: 'GET',
                url: baseUrl + modelName
            });
        };
        var deleteById = function (modelId, modelName) {
            return $http({
                method: 'DELETE',
                url: baseUrl + modelName + "/" + modelId
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