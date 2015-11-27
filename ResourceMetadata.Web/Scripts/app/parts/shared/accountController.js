(function (global) {

    'use strict';

    app.controller('AccountCtrl', ['$scope', '$location', '$http', '$rootScope', '$routeParams', 'accountService', 'UserService', '$uibModal',
        function ($scope, $location, $http, $rootScope, $routeParams, accountService, UserService, $modal) {

            $scope.isRegistrationInProcess = false;
            /*
             "http://c-tr.by/#/Login/userId/dec4b918-a377-42de-afd7-3bca18a2f1a2/code/Mo1O9+ewjJ1VcXeuPVaW+njyw1QbwfH+KapVOoThgoAfWI8FuaL83nAvpqJxy4R+uiP2eh6s02VkFzjqgdhFiyPQ0yzFyrKILXSoTmkShcGF1Y8Gkr5qBoAXmtqvl0RvjmGm+YU9oWVivIDRjuLTbz3JgtdZg3kncTe5qAycMo1cTFGYt7EOWYmbSxoDQke3"
             */

            var modalInstance;

            function showModal() {
                modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'userRegistrationModal.html',
                    scope: $scope
                    //     size: 'sm'
                });
            }

            $scope.closeModal = function () {
                modalInstance.close();
                $location.url('/Adverts/List/Sale');
            };


            function getUrlVars() {
                var vars = {};
                var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                    vars[key] = value;
                });
                return vars;
            }

            function confirmUser() {
                var userId = getUrlVars().userId;
                var code = getUrlVars().code;
                if (userId && code) {
                    accountService.confirmUser(userId, code)
                        .then(function (response) {
                            showModal();
                        }).catch(function (response) {
                            if (response.status === 400) {
                                $scope.errorMessage = response.data.error_description;
                            }
                            else {
                                $scope.errorMessage = "Что-то пошло не так. Попробуйте еще раз.";
                            }
                        });
                }
            }

            // $scope.$on('$routeChangeSuccess', function() {
            confirmUser();
            //  });

            $scope.redirectToLogin = function () {
                $location.url('/Login');
            };

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
                        accountService.getCurrentUser().then(function (userData, qwer) {
                            userData.data.rememberMe = userLogin.rememberMe;
                            UserService.setUserData(userData.data);
                            $scope.$emit('logOn');
                            $location.url('/Adverts/List/Sale');
                        })
                    }).catch(function (response) {
                        if (response.status === 400) {
                            $scope.errorMessage = response.data.error_description;
                        }
                        else {
                            $scope.errorMessage = "Что-то пошло не так. Попробуйте еще раз.";
                        }
                    });
            };

            /*
             http://localhost:7777/#/Login/ae83a3a9-d505-44fa-8d0e-63051c6d9152/mlKGOIMocWWDVvujp8APEliUaOk1w2WOS1jGv4cYCi/LYXpDfmf+ErSdawkTEtZPKo/BEMvFesjQUMCAILyGQc9a5dvqDJ6vs6ulxuFq6shPxgSAeL1qC8X9VnlSTGvOYCqm+PPoR00JPW5KNc4iFZh1UJG0c8k78vwbc6lllrAc1/OLIlGb2dbBJtTbTy5c}
             */
            $scope.register = function (userRegistration) {
                if (!userRegistration) {
                    return;
                }
                if (userRegistration.password !== userRegistration.confirmPassword) {
                    $scope.errorMessage = "Пароли не совпадают";
                    return;
                }
                $scope.errorMessage = '';
                $scope.isRegistrationInProcess = true;
                accountService.registerUser(userRegistration)
                    .then(function (data) {
                        showModal();
                    }).catch(function (response) {
                        if (response.status === 400) {
                            $scope.errorMessage = "Такой email уже существует.";
                        }
                        else {
                            $scope.errorMessage = "Что-то пошло не так. Попробуйте еще раз.";
                        }
                    })
                    .finally(function () {
                        $scope.isRegistrationInProcess = false;
                    })
            };

            $scope.logOff = function () {
                accountService.logOffUser();
                $scope.$emit('logOff');
                $location.url('/Login');
            };


            $rootScope.$on("$routeChangeStart", function (event, next, current) {
                if (next.$$route && next.$$route.originalPath.startsWith('/Admin')) {
                    if (!($rootScope.userData && $rootScope.userData.isAdmin)) {
                        $scope.showAdministrativeTools = false;
                        $location.url('/');
                    } else {
                        $scope.showAdministrativeTools = true;
                    }
                }
            });
        }]);

}(window));


