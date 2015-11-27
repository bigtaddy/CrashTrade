(function (global) {

    'use strict';

    global.app = angular.module('resourceManagerApp', ['ngSanitize', 'ui.select', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities', 'flow', 'ngPhotoSwipe', 'angular-loading-bar', 'ui.bootstrap', 'LocalStorageModule']);

    app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.common.Authorization = 'Bearer ' + global.sessionStorage[global.CrashTradeSettings.tokenKey];

        $locationProvider.html5Mode(false);

        $routeProvider

            .when('/Admin/Manufactures', {
                templateUrl: '/Scripts/app/parts/manufactures/Listing.html',
                controller: 'ManufacturesCtrl'
            })
            .when('/Admin/Manufactures/Add', {
                templateUrl: '/Scripts/app/parts/manufactures/Add.html',
                controller: 'ManufactureCtrl'
            })
            .when('/Admin/Manufactures/Edit/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Edit.html',
                controller: 'ManufactureCtrl'
            })
            .when('/Admin/Manufactures/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Details.html',
                controller: 'ManufactureCtrl'
            })

            .when('/Admin/CarModels', {
                templateUrl: '/Scripts/app/parts/carModels/Listing.html',
                controller: 'CarModelsCtrl'
            })
            .when('/Admin/CarModels/Add', {
                templateUrl: '/Scripts/app/parts/carModels/Add.html',
                controller: 'CarModelCtrl'
            })
            .when('/Admin/CarModels/Edit/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Edit.html',
                controller: 'CarModelCtrl'
            })
            .when('/Admin/CarModels/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Details.html',
                controller: 'CarModelCtrl'
            })


            .when('/Login', {
                templateUrl: '/Scripts/app/parts/shared/Login.html'
            })
            .when('/Login/userId/:userId/code/:code', {
                templateUrl: '/Scripts/app/parts/shared/Login.html'
            })
            .when('/Register', {
                templateUrl: '/Scripts/app/parts/shared/Register.html'
            })

            .when('/About', {
                templateUrl: '/Scripts/app/parts/about/About.html'
            })

            .when('/Adverts/Add', {
                templateUrl: '/Scripts/app/parts/adverts/Add.html',
                controller: 'AdvertCtrl'
            })

            .when('/Adverts/List/:advertType', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl'
            })

            .when('/Adverts/Edit/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Edit.html',
                controller: 'AdvertCtrl'
            })
            .when('/Adverts/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Details.html',
                controller: 'AdvertCtrl'
            })

            .when('/Home', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl'
            })
            .when('/Error', {
                templateUrl: '/Scripts/app/parts/shared/Error.html'
            })
            .otherwise({
                redirectTo: '/Adverts/List/Sale'
            });

        $httpProvider.interceptors.push('authorizationInterceptor');


//        $httpProvider.interceptors.push('httpInterceptor');

    }]).factory('userProfileSvc', function () {

        return {};

    }).run(['$rootScope', 'UserService', 'accountService', '$location', function ($rootScope, UserService, accountService, $location) {
        var userData = UserService.getUserData();
        if (userData && userData.rememberMe) {
            $rootScope.userData = userData;
        } else {
            accountService.logOffUser();
        }
    }]);
    global.utilities = angular.module("custom-utilities", []);


}(window));

