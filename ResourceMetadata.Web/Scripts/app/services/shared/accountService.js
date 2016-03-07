(function (global) {

    'use strict';

    app.factory('accountService', ['$http', 'UserService', '$rootScope', 'localStorageService', function ($http, UserService, $rootScope, localStorageService) {

        var tokenUrl = global.CrashTradeSettings.tokenUrl;

        $rootScope.$on('logOff', function () {
            global.localStorage.removeItem(global.CrashTradeSettings.tokenKey);
            localStorageService.remove(global.CrashTradeSettings.tokenKey);
            $http.defaults.headers.common.Authorization = null;
        });

        return {
            login: function (formData) {
                    return $http({
                        method: 'POST',
                        url: tokenUrl,
                        data: formData,
                        headers: {'Content-Type': 'application/x-www-form-urlencoded'}
                    })
            },

            registerUser: function (userRegistration) {
                //var registration = Account.register(userRegistration);
                //return registration;

                return $http({
                    method: 'POST',
                    url: global.CrashTradeSettings.baseUrl + 'Account/Register/',
                    data: userRegistration
                })
            },
            deleteUser: function (id) {
                return $http({
                    method: 'POST',
                    url: global.CrashTradeSettings.baseUrl + 'Account/DeleteUser/' + id
                })
            },
            changePremiumStatus: function (id) {
                return $http({
                    method: 'POST',
                    url: global.CrashTradeSettings.baseUrl + 'Account/ChangePremiumStatus/' + id
                })
            },
            confirmUser: function (userId, code) {
                return $http({
                    method: 'POST',
                    url: global.CrashTradeSettings.baseUrl + 'Account/ConfirmEmail/',
                    data: {
                        userId: userId,
                        code: code
                    }
                })
            },
            logOffUser: function () {
                $rootScope.$broadcast('logOff');
            },
            getCurrentUser: function () {
                return $http({
                    method: 'GET',
                    url: global.CrashTradeSettings.baseUrl + 'Account/GetCurrentUser/'
                })
            }
        };
    }]);

}(window));



