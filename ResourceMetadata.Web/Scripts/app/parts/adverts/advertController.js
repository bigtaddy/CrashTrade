(function (global) {

    'use strict';

    app.controller('AdvertCtrl', ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService', '$http', 'flowFactory', '$q',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService, $http, flowFactory, $q) {

            $scope.flowObject = flowFactory.create({
                chunkSize: 1024 * 1024
            });

            $scope.advert = {};
            $scope.manufactures = [];
            $scope.carModels = [];
            $scope.advertTypes = [];

            init();

            $scope.isSubmitDisabled = function () {
                var isDisabled = false;
                if ($scope.flowObject.files.length) {
                    for (var i = 0, length = $scope.flowObject.files.length; i < length; i++) {
                        if ($scope.flowObject.files[i].size > 2048000) {
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
                        if ($scope.flowObject.files.length) {
                            var fd = new FormData();
                            var imageFiles = $scope.flowObject.files.forEach(function (file, index) {
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
                            }).success(function (data) {

                            });
                        }
                    });
            };

            /**
             * init
             */
            function init() {
                if ($routeParams.advertId > 0) {
                    $scope.imagesPromise = $q.defer();

                    entityService.getById($routeParams.advertId, "Adverts").then(function (response) {
                        $scope.advert = response.data;
                        getDropDownDataData();
                        getImages();
                    });
                } else {
                    getDropDownDataData();
                }

                $scope.advertTypes = [{Id: 1, Name: "Sale"}, {Id: 2, Name: "Repair"}];
                $scope.fuelTypes = [{Id: 1, Name: "Benzin"}, {Id: 2, Name: "Diesel"}];
            }

            /**
             * setCarModelsByManufactureId
             * @param manufactureId
             */
            function setCarModelsArrayByManufactureId(manufactureId) {
                for (var i = 0; i < $scope.manufactures.length; i++) {
                    if ($scope.manufactures[i].Id == manufactureId) {
                        $scope.carModels = $scope.manufactures[i].CarModels;
                        break;
                    }
                }
            }

            /**
             * getDropDownDataData
             */
            function getDropDownDataData() {
                manufactureService.getAll().then(function (response) {
                    $scope.manufactures = response.data;
                    setCarModelsArrayByManufactureId($scope.advert.ManufactureId);

                    $scope.$watch('advert.ManufactureId', function (newValue, oldValue) {
                        if (newValue != oldValue) {
                            $scope.advert.CarModelId = null;
                            setCarModelsArrayByManufactureId(newValue);
                        }
                    });

                });
            }

            /**
             * getImages
             */
            function getImages() {
                $http({
                    method: 'GET',
                    url: global.CrashTradeSettings.baseUrl + 'Adverts/DownloadImages/' + $scope.advert.Id
                }).success(function (data) {
                    $scope.imagesPromise.resolve(data);
                    $scope.images = data;
                });
            }
        }]);
}(window));


