(function (global) {

    'use strict';

    app.factory('serviceHelperSvc', ['$http', '$resource', function ($http, $resource) {

        var baseUrl = global.CrashTradeSettings.baseUrl;
        var buildUrl = function (resourceUrl) {
            return baseUrl + resourceUrl;
        };

        return {
            Account: $resource(buildUrl('/Account/'), null,
                {
                    register: {method: 'post'},
                    logOff: {method: 'put'}
                }),
            Resource: $resource(buildUrl('/Resources/:resourceId'),
                {resourceId: '@Id'},
                {
                    'update': {method: 'PUT'},
                    getPagedItems: {
                        url: buildUrl("/Resources?count=:count&page=:page&sortField=:sortField&sortOrder=:sortOrder"),
                        method: 'GET',
                        params: {count: '@count', page: '@page', sortField: '@sortField', sortOrder: '@sortOrder'}
                    }
                }),
            Location: $resource(buildUrl('/Locations/:locationId'), {locationId: '@Id'}, {'update': {method: 'PUT'}}),

            Manufacture: $resource(buildUrl('/Manufactures/:manufactureId'), {manufactureId: '@Id'}, {'update': {method: 'PUT'}}),

            CarModel: $resource(buildUrl('/CarModels/:carModelId'), {carModelId: '@Id'}, {'update': {method: 'PUT'}}),


            ResourceActivity: $resource(buildUrl('/Resources/:resourceId/Activities/:activityId'),
                {resourceId: '@ResourceId', activityId: '@Id'})
        };
    }]);

}(window));

