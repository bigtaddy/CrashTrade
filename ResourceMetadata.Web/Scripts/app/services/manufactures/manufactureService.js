(function (global) {

    'use strict';

    app.factory('manufactureService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

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


        return {
            getById: getById,
            getAll: getAll
        };
    }]);

}(window));
