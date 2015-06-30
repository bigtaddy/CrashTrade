(function (global) {

    'use strict';

    app.controller('AdvertCtrl', ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService', '$http', 'flowFactory',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService, $http, flowFactory) {

            $scope.flowObject = flowFactory.create({
                chunkSize: 1024 * 1024
            });

            $scope.advert = {};
            $scope.manufactures = [];
            $scope.carModels = [];

            init();

            $scope.isSubmitDisabled = function () {
                var isDisabled = false;
                if($scope.flowObject.files.length) {
                    for(var i = 0, length = $scope.flowObject.files.length; i < length; i++){
                        if($scope.flowObject.files[i].size > 2048000) {
                            isDisabled = true;
                            break;
                        }
                    }
                }
                return isDisabled;
            };

            /**
             * addAdvert
             * @param advert
             */
            $scope.addAdvert = function (advert) {
                entityService.add(advert, "Adverts")
                    .then(function (data) {
                        $location.url('/Adverts/List/My');
                    });
            };

            /**
             * editAdvert
             * @param advert
             */
            $scope.editAdvert = function (advert) {

                entityService.edit(advert, "Adverts")
                    .then(function (data) {
                        if($scope.flowObject.files.length) {
                            var fd = new FormData();
                            var imageFiles = $scope.flowObject.files.forEach(function(file, index){
                                fd.append(('file' + index), file.file);
                            });
                            $http({
                                method: 'POST',
                                url: global.CrashTradeSettings.baseUrl + 'Adverts/UploadImages/' + advert.Id,
                                data: fd,
                                transformRequest: angular.identity,
                                headers: {
                                    'Content-Type': undefined,
                                    'enctype': 'multipart/form-data'

                                }
                            }).success(function(data){

                            });
                        }
                    /*    $scope.flowObject.defaults.target = global.CrashTradeSettings.baseUrl + 'Adverts/UploadImage/' + advert.Id;
                        $scope.flowObject.defaults.withCredentials = true;
                        $scope.flowObject.defaults.headers.Authorization = 'Bearer ' + global.sessionStorage[global.CrashTradeSettings.tokenKey];
                        $scope.flowObject.upload();
                        $location.url('/Adverts/List/My');*/
                    });
            };


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


