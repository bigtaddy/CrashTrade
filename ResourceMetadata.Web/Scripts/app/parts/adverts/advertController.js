(function (global) {

    'use strict';

    app.controller('AdvertCtrl', ['$scope', '$location', '$routeParams', 'entityService', 'manufactureService', 'carModelService', 'advertService', 'FileUploader', '$http', 'flowFactory',
        function ($scope, $location, $routeParams, entityService, manufactureService, carModelService, advertService, FileUploader, $http, flowFactory) {

            $scope.flowObject = flowFactory.create();

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
                var fd = new FormData();
                var imageFiles = $scope.flowObject.files.forEach(function(file, index){
                    fd.append(('file' + index), file.file);
                });
                entityService.edit(advert, "Adverts")
                    .then(function (data) {
                        $http({
                            method: 'POST',
                            url: global.CrashTradeSettings.baseUrl + 'Adverts/UploadImage/' + advert.Id,
                            data: fd,
                            transformRequest: angular.identity,
                            headers: {
                                'Content-Type': undefined,
                                'enctype': 'multipart/form-data'

                            }
                        }).success(function(data){

                        });
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


          /*  var uploader = $scope.uploader = new FileUploader();
            uploader.headers.Authorization = 'Bearer ' + global.sessionStorage[global.CrashTradeSettings.tokenKey];


            uploader.filters.push({
                name: 'imageFilter',
                fn: function(item , options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            });


            uploader.onWhenAddingFileFailed = function(item , filter, options) {
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
            };*/


        }]);

}(window));


