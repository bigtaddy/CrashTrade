(function(global) {

    'use strict';

    app.factory('manufactureService', ['$http', '$q', function($http, $q, $timeout) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var add = function(manufacture) {
            return $http({
                method: 'POST',
                url: baseUrl + 'Manufactures',
                data: manufacture
            });
        };
        var edit = function(manufacture) {
            return $http({
                method: 'PUT',
                url: baseUrl + 'Manufactures/' + manufacture.Id,
                data: manufacture
            });
        };
        var getById = function(manufactureId) {
            return $http({
                method: 'GET',
                url: baseUrl + 'Manufactures/' + manufactureId
            });
        };

        var getAll = function(fromServer) {
            var deferred = $q.defer();

            var manufactures = global.sessionStorage.getItem('manufactures');
            if (manufactures && !fromServer) {
                deferred.resolve(JSON.parse(manufactures));
            } else {
                $http({
                    method: 'GET',
                    url: baseUrl + 'Manufactures'
                }).then(function(response) {
                    global.sessionStorage.setItem('manufactures', JSON.stringify(response));
                    deferred.resolve(response);
                });
            }

            return deferred.promise;
        };

        var deleteById = function(manufactureId) {
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
