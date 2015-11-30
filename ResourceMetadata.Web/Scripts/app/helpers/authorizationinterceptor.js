(function(global) {

    'use strict';

    app.factory('authorizationInterceptor', ['$rootScope', '$q', '$location', function ($rootScope, $q, $location, $http) {
        return {
            response: function (response) {
                /*if (!global.sessionStorage[global.CrashTradeSettings.tokenKey]) {
                    $rootScope.$broadcast('logOff');
                    if($location.$$path !== '/Register') {
                        $location.url('/Login');
                    }
                }*/
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
                    case 405:
                    case 403:
                    {
                        alert('Permission Denied')
                        $location.url('/');
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

