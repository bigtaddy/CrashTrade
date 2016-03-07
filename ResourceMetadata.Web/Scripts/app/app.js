(function (global) {

    'use strict';

    global.app = angular.module('resourceManagerApp', ['ngSanitize', 'ui.select', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities', 'flow', 'ngPhotoSwipe', 'angular-loading-bar', 'ui.bootstrap', 'LocalStorageModule', 'truncate']);

    app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.common.Authorization = 'Bearer ' + global.localStorage[global.CrashTradeSettings.tokenKey];

        $locationProvider.html5Mode(false);

        $routeProvider.when('/Admin/Manufactures', {
                templateUrl: '/Scripts/app/parts/manufactures/Listing.html',
                controller: 'ManufacturesCtrl',
                data: {
                    menuSection: 'Manufactures'
                }
            })
            .when('/Admin/Manufactures/Add', {
                templateUrl: '/Scripts/app/parts/manufactures/Add.html',
                controller: 'ManufactureCtrl',
                data: {
                    menuSection: 'Manufactures'
                }
            })
            .when('/Admin/Manufactures/Edit/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Edit.html',
                controller: 'ManufactureCtrl',
                data: {
                    menuSection: 'Manufactures'
                }
            })
            .when('/Admin/Manufactures/:manufactureId', {
                templateUrl: '/Scripts/app/parts/manufactures/Details.html',
                controller: 'ManufactureCtrl',
                data: {
                    menuSection: 'Manufactures'
                }
            })
            .when('/Admin/CarModels', {
                templateUrl: '/Scripts/app/parts/carModels/Listing.html',
                controller: 'CarModelsCtrl',
                data: {
                    menuSection: 'CarModels'
                }
            })
            .when('/Admin/CarModels/Add', {
                templateUrl: '/Scripts/app/parts/carModels/Add.html',
                controller: 'CarModelCtrl',
                data: {
                    menuSection: 'CarModels'
                }
            })
            .when('/Admin/CarModels/Edit/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Edit.html',
                controller: 'CarModelCtrl',
                data: {
                    menuSection: 'CarModels'
                }
            })
            .when('/Admin/CarModels/:carModelId', {
                templateUrl: '/Scripts/app/parts/carModels/Details.html',
                controller: 'CarModelCtrl',
                data: {
                    menuSection: 'CarModels'
                }
            })
            .when('/Admin/Users', {
                templateUrl: '/Scripts/app/parts/userManagement/Listing.html',
                controller: 'UserManagementCtrl',
                data: {
                    menuSection: 'Users'
                }
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
                templateUrl: '/Scripts/app/parts/about/About.html',
                data: {
                    menuSection: 'About'
                }
            })
            .when('/Adverts/Add', {
                templateUrl: '/Scripts/app/parts/adverts/Add.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'Advert',
                    menuSection: 'AddAdvert'
                }
            })
            .when('/Adverts/List/Sale', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl',
                data: {
                    advertType: 'Sale',
                    menuSection: 'SaleAdverts'
                }
            })
            .when('/Adverts/List/MechanicalRepair', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl',
                data: {
                    advertType: 'MechanicalRepair',
                    menuSection: 'MechanicalRepairAdverts'
                }
            })
            .when('/Adverts/List/CoachworkRepair', {
                templateUrl: '/Scripts/app/parts/adverts/Listing.html',
                controller: 'AdvertsCtrl',
                data: {
                    advertType: 'CoachworkRepair',
                    menuSection: 'CoachworkRepairAdverts'
                }
            })
            .when('/Adverts/List/My', {
                templateUrl: '/Scripts/app/parts/adverts/ListingOfMyAdverts.html',
                controller: 'AdvertsCtrl',
                data: {
                    advertType: 'My',
                    menuSection: 'MyAdverts'
                }
            })
            .when('/Adverts/Edit/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Edit.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'Advert'
                }
            })
            .when('/Adverts/:advertId', {
                templateUrl: '/Scripts/app/parts/adverts/Details.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'Advert'
                }
            })
            .when('/Adverts/List/SparePart', {
                templateUrl: '/Scripts/app/parts/SparePartAdverts/Listing.html',
                controller: 'AdvertsCtrl',
                data: {
                    advertType: 'SparePart',
                    menuSection: 'SparePartAdverts'
                }
            })

            .when('/SparePartAdverts/Add', {
                templateUrl: '/Scripts/app/parts/SparePartAdverts/Add.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'SparePartAdvert',
                    menuSection: 'AddAdvert'
                }
            })
            .when('/SparePartAdverts/Edit/:advertId', {
                templateUrl: '/Scripts/app/parts/SparePartAdverts/Edit.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'SparePartAdvert'
                }
            })
            .when('/SparePartAdverts/:advertId', {
                templateUrl: '/Scripts/app/parts/SparePartAdverts/Details.html',
                controller: 'AdvertCtrl',
                data: {
                    advertType: 'SparePartAdvert'
                }
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
    }).run(['$rootScope', 'UserService', '$location', 'localStorageService', '$http', function ($rootScope, UserService, $location, localStorageService, $http) {
        var userData = UserService.getUserData();
        if (userData && userData.rememberMe) {
            $rootScope.userData = userData;
            global.localStorage.setItem(
                global.CrashTradeSettings.tokenKey,
                localStorageService.get(global.CrashTradeSettings.tokenKey)
            );
            $http.defaults.headers.common.Authorization = 'Bearer ' + global.localStorage[global.CrashTradeSettings.tokenKey];
        } else {
            if (!global.localStorage[global.CrashTradeSettings.tokenKey]) {
                $rootScope.$broadcast('logOff');
            } else {
                $rootScope.userData = userData;
            }
        }
    }]);

    global.utilities = angular.module("custom-utilities", []);

}(window));

