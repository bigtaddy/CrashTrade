﻿(function (global) {

    'use strict';

    app.directive('cstTopMenu', function ($location, $rootScope) {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: 'Scripts/app/partials/TopMenu.html',
            link: function (scope, element, attrs) {
                var menuItems = element.find("a");
                menuItems.on('click', function () {
                    menuItems.removeClass('active');
                    angular.element(this).addClass('active');
                });

                if (global.sessionStorage[global.CrashTradeSettings.tokenKey]) {
                    scope.isAuthenticated = true;
                }
                scope.$on('logOff', function () {
                    $rootScope.isAuthenticated = false;
                });

                scope.$on('logOn', function () {
                    $rootScope.isAuthenticated = true;
                });

                scope.goToRegistration = function () {
                    $location.url('/Register');
                };

                scope.goToLogin = function () {
                    $location.url('/Login');
                };

                $rootScope.$on("$routeChangeSuccess", function (event, next, current) {
                    if (next.$$route && next.$$route.originalPath.startsWith('/Admin')) {
                        if (!($rootScope.userData && $rootScope.userData.isAdmin)) {
                            scope.showAdministrativeTools = false;
                            $location.url('/');
                        } else {
                            scope.showAdministrativeTools = true;
                        }
                    } else {
                        scope.showAdministrativeTools = false;
                    }
                });
            }
        };
    });

}(window));

