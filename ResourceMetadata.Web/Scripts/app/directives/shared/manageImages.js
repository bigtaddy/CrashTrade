/**
 * Created by a.kravtsov on 8/4/2015.
 */
(function (global) {

    'use strict';

    utilities.directive('manageImages', ['entityService', function (entityService) {
        return {
            restrict: 'E',
            scope: {
                images: "="
            },
            template: '<div>' +
            '  <div ng-repeat="image in images" class="gallery-box ng-scope">' +
            '    <div class="thumbnail">' +
            '      <img src="{{image.FullName}}">' +
            '    </div>' +

            '    <div class="btn-group">' +
            '      <a class="btn btn-xs btn-danger" ng-click="deleteImage(image.Id, $index)"> Delete </a>' +
            '    </div>' +
            '  </div>' +
            '</div>',
            link: function (scope, element, attrs) {
                scope.deleteImage = function (imageId, index) {


                    entityService.deleteById(imageId, "Adverts/DeleteImages")
                        .then(function (data) {
                            scope.images.splice(index, 1)
                        });


                }
            }
        };
    }]);

}(window));