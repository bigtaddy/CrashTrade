(function (global) {

    'use strict';

    app.controller('AccountCtrl', ['$scope', '$location', '$http', 'accountService', 'userProfileSvc',
        function ($scope, $location, $http, accountService, userProfileSvc) {

        var buildFormData = function (formData) {
            var dataString = '';
            for (var prop in formData) {
                if (formData.hasOwnProperty(prop)) {
                    dataString += (prop + '=' + formData[prop] + '&');
                }
            }
            return dataString.slice(0, dataString.length - 1);
        };

        $scope.login = function (userLogin) {
            $scope.errorMessage = '';
            var formData = {username: userLogin.Email, password: userLogin.Password, grant_type: 'password'};
            accountService.login(buildFormData(formData))
                .then(function (response) {
                    $http.defaults.headers.common.Authorization = "Bearer " + response.data.access_token;
                    global.sessionStorage.setItem(global.CrashTradeSettings.tokenKey, response.data.access_token);
                    userProfileSvc.role = response.data.role;
                    $scope.$emit('logOn');
                    $location.url('/Home');
                }).catch(function (errorResponse) {
                    if (errorResponse.status == 404) {
                        $scope.errorMessage = errorResponse.data;
                    }
                    if (errorResponse.status === 400) {
                        $scope.errorMessage = "Неверный Email/Пароль";
                    }
                    else {
                        $scope.errorMessage = "An error occured while performing this action. Please try after some time.";
                    }
                });
        };

        $scope.register = function (userRegistration) {
            if (userRegistration.password !== userRegistration.confirmPassword) {
                $scope.errorMessage = "Пароли не совпадают";
                return;
            }

            $scope.errorMessage = '';

            accountService.registerUser(userRegistration)
                .then(function (data) {
                    var formData = {username: userRegistration.Email, password: userRegistration.Password, grant_type: 'password'};
                    return accountService.login(buildFormData(formData)).then(function (response) {
                        $http.defaults.headers.common.Authorization = "Bearer " + response.data.access_token;
                        global.sessionStorage.setItem(global.CrashTradeSettings.tokenKey, response.data.access_token);
                        userProfileSvc.role = response.data.role;
                        $scope.$emit('logOn');
                        $location.url('/Home');
                        });
                }).catch(function (error) {
                    if (error.status === 400) {
                        $scope.errorMessage = "Такой email уже существует.";
                    }
                    else {
                        $scope.errorMessage = "An error occured while performing this action. Please try after some time.";
                    }
                });
        };

        $scope.logOff = function () {
            accountService.logOffUser();
            $scope.$emit('logOff');
        };
    }]);

}(window));


