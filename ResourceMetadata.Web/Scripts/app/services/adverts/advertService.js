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
                var url = baseUrl + "Adverts/GetAll" + advertTypeName + "/?pageNumber=" + currentPage + "&itemsPerPage="
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

        return {
            getAll: getAll,
            verifyAdvertType: verifyAdvertType
        };
    }]);

}(window));