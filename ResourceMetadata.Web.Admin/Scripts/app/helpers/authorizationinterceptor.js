(function(global) {

    'use strict';

    app.factory('authorizationInterceptor', ['$rootScope', '$q', '$location', function ($rootScope, $q, $location) {
        return {
            response: function (response) {
                if (!global.sessionStorage[global.CrashTradeSettings.tokenKey]) {
                    $rootScope.$broadcast('logOff');
                    $location.url('/Login');
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                switch (rejection.status) {
                    case 401:
                    {
                        global.sessionStorage.removeItem(global.CrashTradeSettings.tokenKey);
                        $http.defaults.headers.common.Authorization = null;
                        $rootScope.$broadcast('logOff');
                        $location.url('/Login');
                        break;
                    }
                    case 403:
                    {
                        $rootScope.$broadcast('logOff');
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

