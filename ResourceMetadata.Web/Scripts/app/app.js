(function(global) {

    'use strict';

    global.app = angular.module('resourceManagerApp', ['ui.select2', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities']);

    app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', function ($routeProvider, $locationProvider, $httpProvider, $provide) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.common.Authorization = 'Bearer ' + global.localStorage[global.CrashTradeSettings.tokenKey];

        $locationProvider.html5Mode(false);

        $routeProvider
            .when('/Login', {
                templateUrl: '/Scripts/app/parts/shared/Login.html'
            })
            .when('/Register', {
                templateUrl: '/Scripts/app/parts/shared/Register.html'
            })
            .when('/Locations', {
                templateUrl: '/Scripts/app/parts/locations/Locations.html',
                controller: 'LocationsCtrl'
            })
            .when('/About', {
                templateUrl: '/Scripts/app/parts/about/About.html'
            })
            .when('/Locations/Add', {
                templateUrl: '/Scripts/app/parts/locations/Add.html',
                controller: 'LocationCtrl'
            })
            .when('/Locations/Edit/:locationId', {
                templateUrl: '/Scripts/app/parts/locations/Edit.html',
                controller: 'LocationCtrl'
            })
            .when('/Resources', {
                templateUrl: '/Scripts/app/parts/resources/Resources-ng-table.html',
                controller: 'ResourcesCtrl'
            })
            .when('/Resources/Add', {
                templateUrl: '/Scripts/app/parts/resources/Add.html',
                controller: 'ResourceCtrl'
            })
            .when('/Resources/Edit/:resourceId', {
                templateUrl: '/Scripts/app/parts/resources/Edit.html',
                controller: 'ResourceEditCtrl'
            })
            .when('/Resources/:resourceId', {
                templateUrl: '/Scripts/app/parts/resources/Details.html',
                controller: 'ResourceCtrl'
            })
            .when('/Activities/Add', {
                templateUrl: '/Scripts/app/parts/activities/Add.html',
                controller: 'ActivityAddCtrl'
            })

            .when('/Manufactures', {
                templateUrl: '/Scripts/app/parts/manufactures/Listing.html',
                controller: 'ManufacturesCtrl'
            })
            .when('/Manufactures/Add', {
                templateUrl: '/Scripts/app/parts/manufactures/Add.html',
                controller: 'ManufactureCtrl'
            })
            .when('/Manufactures/Edit/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Edit.html',
                controller: 'ManufactureCtrl'
            })
            .when('/Manufactures/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Details.html',
                controller: 'ManufactureCtrl'
            })

            .when('/CarModels', {
                templateUrl: '/Scripts/app/parts/carModels/Listing.html',
                controller: 'CarModelsCtrl'
            })
            .when('/CarModels/Add', {
                templateUrl: '/Scripts/app/parts/carModels/Add.html',
                controller: 'CarModelCtrl'
            })
            .when('/CarModels/Edit/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Edit.html',
                controller: 'CarModelCtrl'
            })
            .when('/CarModels/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Details.html',
                controller: 'CarModelCtrl'
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
    });

    global.utilities = angular.module("custom-utilities", []);


}(window));

