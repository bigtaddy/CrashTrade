(function (global) {

    'use strict';

    app.controller('AdvertCtrl',
        ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService', '$http', 'flowFactory', '$q', '$route',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService, $http, flowFactory, $q, $route) {

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
                if (!verifyAdvertTypes(advert)) {
                    return;
                }

                var url = "Adverts/Create";

                if ($route.current.data.advertType == 'SparePartAdvert') {
                    url = "SparePartAdverts/Create";
                }

                entityService.add(advert, url)
                    .then(function (response) {
                        uploadImages(response.data.Id, function () {
                            $location.path('/Adverts/List/My');
                        });
                    });
            };

            /**
             * editAdvert
             * @param advert
             */
            $scope.editAdvert = function (advert) {
                if (!verifyAdvertTypes(advert)) {
                    return;
                }

                var url = "Adverts/Edit";

                if ($route.current.data.advertType == 'SparePartAdvert') {
                    url = "SparePartAdverts/Edit";
                }
                entityService.edit(advert, url)
                    .then(function () {
                        uploadImages(advert.Id, function () {
                            $location.path('/Adverts/List/My');
                        });

                    });
            };

            /**
             * init
             */
            function init() {
                if ($routeParams.advertId > 0) {
                    $scope.imagesPromise = $q.defer();

                    var url = "Adverts/GetById";

                    if ($route.current.data.advertType == 'SparePartAdvert') {
                        url = "SparePartAdverts/GetById";
                    }

                    entityService.getById($routeParams.advertId, url).then(function (response) {
                        $scope.advert = response.data;
                        getDropDownDataData();
                        $scope.imagesPromise.resolve($scope.advert.ImageInfos);
                        $scope.images = $scope.advert.ImageInfos;
                    });
                } else {
                    getDropDownDataData();
                }

                $scope.CrashTradeSettings = CrashTradeSettings;
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
             * verifyAdvertTypes
             * @param advert
             * @returns {boolean}
             */
            function verifyAdvertTypes(advert) {
                if ($route.current.data.advertType != 'SparePartAdvert') {
                    if (!(advert.SaleType || advert.CoachworkRepairType || advert.MechanicalRepairType)) {
                        alert('Пожалуйста, выберите тип объявления.');

                        return false;
                    }
                }
                return true;
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


