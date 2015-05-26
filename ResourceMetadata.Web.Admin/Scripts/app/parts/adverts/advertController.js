(function (global) {

    'use strict';

    app.controller('AdvertCtrl', ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService) {
            $scope.advert = {};
            $scope.manufactures = [];
            $scope.carModels = [];

            $scope.advertType = $routeParams.advertType;
            if(advertService.getCodeOfAdvertType($scope.advertType) == false){
                $location.url('/Home');
            }


            init();

            /**
             * addAdvert
             * @param advert
             */
            $scope.addAdvert = function (advert) {
                advert.AdvertType = advertService.getCodeOfAdvertType($scope.advertType);
                entityService.add(advert, "Adverts")
                    .then(function (data) {
                        $location.url('/Adverts/' + $routeParams.advertType);
                    });
            };

            /**
             * editAdvert
             * @param advert
             */
            $scope.editAdvert = function (advert) {
                entityService.edit(advert, "Adverts")
                    .then(function (data) {
                        $location.url('/Adverts/'+ $routeParams.advertType);
                    });
            };

            /**
             * init
             */
            function init() {
                if ($routeParams.advertId > 0) {
                    entityService.getById($routeParams.advertId, "Adverts").then(function (response) {
                        $scope.advert = response.data;
                    });
                }
                manufactureService.getAll().then(function (response) {
                    $scope.manufactures = response.data;
                });
                carModelService.getAll().then(function (response) {
                    $scope.carModels = response.data;
                });
            }
        }]);

}(window));


