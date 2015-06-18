(function (global) {

    'use strict';

    app.controller('AdvertCtrl', ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService', 'FileUploader', '$http',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService, FileUploader, $http) {
            $scope.advert = {};
            $scope.manufactures = [];
            $scope.carModels = [];


            init();

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
                        $location.url('/Adverts/List/My');
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


            var uploader = $scope.uploader = new FileUploader();
            uploader.headers.Authorization = 'Bearer ' + global.sessionStorage[global.CrashTradeSettings.tokenKey];

            // FILTERS

            uploader.filters.push({
                name: 'imageFilter',
                fn: function(item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            });

            // CALLBACKS

            uploader.onWhenAddingFileFailed = function(item /*{File|FileLikeObject}*/, filter, options) {
                console.info('onWhenAddingFileFailed', item, filter, options);
            };
            uploader.onAfterAddingFile = function(fileItem) {
                console.info('onAfterAddingFile', fileItem);
            };
            uploader.onAfterAddingAll = function(addedFileItems) {
                console.info('onAfterAddingAll', addedFileItems);
            };
            uploader.onBeforeUploadItem = function(item) {
                item.url = 'http://localhost:7777/api/Adverts/UploadImage/' + $scope.advert.Id

                console.info('onBeforeUploadItem', item);
            };
            uploader.onProgressItem = function(fileItem, progress) {
                console.info('onProgressItem', fileItem, progress);
            };
            uploader.onProgressAll = function(progress) {
                console.info('onProgressAll', progress);
            };
            uploader.onSuccessItem = function(fileItem, response, status, headers) {
                console.info('onSuccessItem', fileItem, response, status, headers);
            };
            uploader.onErrorItem = function(fileItem, response, status, headers) {
                console.info('onErrorItem', fileItem, response, status, headers);
            };
            uploader.onCancelItem = function(fileItem, response, status, headers) {
                console.info('onCancelItem', fileItem, response, status, headers);
            };
            uploader.onCompleteItem = function(fileItem, response, status, headers) {
                console.info('onCompleteItem', fileItem, response, status, headers);
            };
            uploader.onCompleteAll = function() {
                console.info('onCompleteAll');
            };

            console.info('uploader', uploader);





















        }]);

}(window));


