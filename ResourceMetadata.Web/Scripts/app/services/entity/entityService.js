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
        var getById = function (id, modelName) {
            return $http({
                method: 'GET',
                url: baseUrl + modelName,
                params: {id: id}
            });
        };

        var getAll = function (modelName) {
            return $http({
                method: 'GET',
                url: baseUrl + modelName
            });
        };

        var deleteById = function (id, modelName) {
            return $http({
                method: 'DELETE',
                url: baseUrl + modelName,
                params: {id: id}
            });
        };

        var deleteByIds = function (ids,  modelName) {
            return $http({
                method: 'POST',
                url: baseUrl + modelName + '/DeleteByIds/',
                data: ids
            })
        };



        return {
            add: add,
            edit: edit,
            getById: getById,
            getAll: getAll,
            deleteById: deleteById,
            deleteByIds: deleteByIds
        };
    }]);

}(window));