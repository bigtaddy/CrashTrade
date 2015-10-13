/**
 * Created by a.kravtsov on 5/24/2015.
 */
(function (global) {

    'use strict';

    app.factory('advertService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var getAll = function (advertTypeName, currentPage, pageSize, sortOptions, filterOptions) {
            if (advertTypeName == 'My') {
                var url = baseUrl + "Adverts/My/?pageNumber=" + currentPage + "&itemsPerPage="
                    + pageSize + "&sortOptions=" + sortOptions + "&filterOptions=" + filterOptions;
            } else {
                filterOptions = "(" + filterOptions + (") And " + advertTypeName + "Type = true" );
                var url = baseUrl + "Adverts/All/?pageNumber=" + currentPage + "&itemsPerPage="
                    + pageSize + "&sortOptions=" + sortOptions + "&filterOptions=" + filterOptions;
            }

            return $http({
                method: 'GET',
                url: url
            });
        };

        var verifyAdvertType = function (type) {
            return (type == 'Sale' || type == 'Repair');
        };

        var validateAdvertType = function (type) {
            if (type == 'Sale' || type == 'MechanicalRepair' || type == 'CoachworkRepair') {
                return true
            }

            return false;
        };

        return {
            getAll: getAll,
            validateAdvertType: validateAdvertType,
            verifyAdvertType: verifyAdvertType
        };
    }]);

}(window));