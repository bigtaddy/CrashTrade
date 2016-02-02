/**
 * Created by a.kravtsov on 8/4/2015.
 */
(function (global) {

    'use strict';
    utilities.directive('manageImages', ['entityService', function (entityService) {
        return {
            restrict: 'E',
            scope: {
                images: "=",
                advertId: "="
            },
            template: '<div class="img_scrollbar">' +
            '  <div ng-repeat="image in images" style="display: inline-block;">' +
            '      <img ng-src="{{image.FullName}}" style="max-height: 90px" class="img-rounded img-responsive shadow">' +
            '      <a class="btn btn-xs btn-danger" style="margin-top: 10px; margin-bottom: 5px" ng-click="deleteImage(image.Id, $index)"> Удалить </a>' +
            '  </div>' +
            '</div>',
            link: function (scope, element, attrs) {
                scope.deleteImage = function (imageId, index) {

                    entityService.deleteByIds([imageId], 'Images')
                        .then(function (data) {
                            scope.images.splice(index, 1)
                        });
                }
            }
        };
    }]);

}(window));
