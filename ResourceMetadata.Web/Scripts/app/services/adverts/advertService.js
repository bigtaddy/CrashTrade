/**
 * Created by a.kravtsov on 5/24/2015.
 */
(function (global) {

    'use strict';

    app.factory('advertService', ['$http', function ($http) {

        var baseUrl = global.CrashTradeSettings.baseUrl;

        var getAll = function (advertTypeName, currentPage, pageSize, sortOptions, filterOptions) {
            if (advertTypeName == undefined) {
                var url = baseUrl + "Adverts/All/?pageNumber=" + currentPage + "&itemsPerPage=" + pageSize + "&sortOptions="
                    + sortOptions + "&filterOptions=" + filterOptions;
            } else if (advertTypeName == 'My') {
                var url = baseUrl + "Adverts/My/?pageNumber=" + currentPage + "&itemsPerPage="
                    + pageSize + "&sortOptions=" + sortOptions + "&filterOptions=" + filterOptions;
            } else {
                filterOptions += (" And AdvertType=\"" + advertTypeName + "\"" );
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

        var getCodeOfAdvertType = function (type) {
            if (type == 'Sale') {
                return 2
            } else if (type == 'Repair') {
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