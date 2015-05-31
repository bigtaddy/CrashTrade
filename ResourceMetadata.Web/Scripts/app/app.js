(function(global) {

    'use strict';

    global.app = angular.module('resourceManagerApp', ['ui.select2', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities', 'angularFileUpload']);

    app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.common.Authorization = 'Bearer ' + global.sessionStorage[global.CrashTradeSettings.tokenKey];

        $locationProvider.html5Mode(false);

        $routeProvider
            .when('/Login', {
                templateUrl: '/Scripts/app/parts/shared/Login.html'
            })
            .when('/Register', {
                templateUrl: '/Scripts/app/parts/shared/Register.html'
            })

            .when('/About', {
                templateUrl: '/Scripts/app/parts/about/About.html'
            })

            .when('/Adverts/:advertType', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl'
            })
            .when('/Adverts/:advertType/Add', {
                templateUrl: '/Scripts/app/parts/adverts/Add.html',
                controller: 'AdvertCtrl'
            })
            .when('/Adverts/:advertType/Edit/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Edit.html',
                controller: 'AdvertCtrl'
            })
            .when('/Adverts/:advertType/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Details.html',
                controller: 'AdvertCtrl'
            })

            .when('/Home', {
                templateUrl: '/Scripts/app/parts/home/Home.html', controller: 'HomeCtrl'
            })
            .when('/Error', {
                templateUrl: '/Scripts/app/parts/shared/Error.html'
            })
            .otherwise({
                redirectTo: '/Home'
            });

        $httpProvider.interceptors.push('authorizationInterceptor');
        $httpProvider.interceptors.push('httpInterceptor');

    }]).factory('userProfileSvc', function () {

        return {};

    }).run(['$rootScope', function ($rootScope) {


    }]);
    global.utilities = angular.module("custom-utilities", ['mm.foundation']);


}(window));

