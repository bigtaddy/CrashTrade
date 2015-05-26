/**
 * Created by a.kravtsov on 5/24/2015.
 */
(function (global) {

    'use strict';

    app.factory('advertService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var getAll = function (advertTypeName) {
            return $http({
                method: 'GET',
                url: baseUrl + "Adverts/" + advertTypeName
            });
        };

        var verifyAdvertType = function (type) {
            return (type == 'Sale' || type == 'Repair');
        };

        var getCodeOfAdvertType = function (type) {
            if(type == 'Sale'){
                return 2
            }else if(type == 'Repair'){
                return 1
            }

            return false;
        };

        return {
            getAll: getAll,
            getCodeOfAdvertType: getCodeOfAdvertType,
            verifyAdvertType: verifyAdvertType
        };
    }]);

}(window));