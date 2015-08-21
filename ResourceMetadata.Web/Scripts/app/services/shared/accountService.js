(function (global) {

    'use strict';

    app.factory('accountService', ['$http', 'serviceHelperSvc', function ($http, serviceHelper) {

        var tokenUrl = global.CrashTradeSettings.tokenUrl;

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
            logOffUser: function () {
                global.sessionStorage.removeItem(global.CrashTradeSettings.tokenKey);
                $http.defaults.headers.common.Authorization = null;
            }
        };
    }]);

}(window));



