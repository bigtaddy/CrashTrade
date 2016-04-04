(function (global) {

    'use strict';

    app.directive('cstTopMenu', function ($location, $rootScope, $route) {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: 'Scripts/app/partials/TopMenu.html',
            link: function (scope) {

                scope.isCollapsed = true;

                if($route.current && $route.current.data){
                    scope.currentMenuSection = $route.current.data.menuSection;
                }

                if (global.localStorage[global.CrashTradeSettings.tokenKey]) {
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

                    if($route.current.data){
                        scope.currentMenuSection = $route.current.data.menuSection;
                    }

                    scope.isCollapsed = true;
                });

            }
        };
    });

}(window));

