(function(global) {

    'use strict';

    app.factory('authorizationInterceptor', ['$rootScope', '$q', '$location', function ($rootScope, $q, $location) {
        return {
            response: function (response) {
                if (!global.localStorage[global.CrashTradeSettings.tokenKey]) {
                    $rootScope.$broadcast('logOff');
                    $location.url('/Login');
                } else {
                    $rootScope.$broadcast('logOn');
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                switch (rejection.status) {
                    case 401:
                    {
                        $rootScope.$broadcast('logOff');
                        $location.url('/Login');
                        break;
                    }
                    case 403:
                    {
                        $location.url('/Login');
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }

                return $q.reject(rejection);
            }
        };
    }]);

}(window));

