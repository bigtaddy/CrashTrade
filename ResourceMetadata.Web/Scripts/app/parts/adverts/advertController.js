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

            init();

            /**
             * isSubmitDisabled
             * @returns {boolean}
             */
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
             * uploadImages
             * @param advertId
             * @param callback
             */
            function uploadImages(advertId, callback) {
                if ($scope.flowObject.files.length) {
                    var fd = new FormData();
                    var imageFiles = $scope.flowObject.files.forEach(function (file, index) {
                        fd.append(('file' + index), file.file);
                    });
                    $http({
                        method: 'POST',
                        url: global.CrashTradeSettings.baseUrl + 'Images/' + advertId,
                        data: fd,
                        transformRequest: angular.identity,
                        headers: {
                            'Content-Type': undefined,
                            'enctype': 'multipart/form-data'

                        }
                    }).success(function () {
                        if (callback) {
                            callback();
                        }
                    });
                } else {
                    callback();
                }
            }

            /**
             * addAdvert
             * @param advert
             */
            $scope.addAdvert = function (advert) {
                entityService.add(advert, "Adverts/Save")
                    .then(function (response) {
                        uploadImages(response.data.Id, function () {
                            $location.path('/Adverts/List/My');
                        })
                    });
            };

            /**
             * editAdvert
             * @param advert
             */
            $scope.editAdvert = function (advert) {
                entityService.edit(advert, "Adverts")
                    .then(function (response) {
                        uploadImages(advert.Id, function () {
                            $location.path('/Adverts/List/My');
                        })

                    });
            };

            /**
             * init
             */
            function init() {
                if ($routeParams.advertId > 0) {
                    $scope.imagesPromise = $q.defer();

                    entityService.getById($routeParams.advertId, "Adverts/GetById").then(function (response) {
                        $scope.advert = response.data;
                        getDropDownDataData();
                        $scope.imagesPromise.resolve($scope.advert.ImageInfos);
                        $scope.images = $scope.advert.ImageInfos;
                    });
                } else {
                    getDropDownDataData();
                }

                $scope.fuelTypes = [{Id: 1, Name: "Бензин"}, {Id: 2, Name: "Дизель"}];
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
        }]);
}(window));


