/**
 * Created by a.kravtsov on 8/12/2015.
 */

(function (global) {

    'use strict';

    /**
     * loadImages
     */
    app.directive("loadImages", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/app/parts/adverts/loadImagesDirective.html",
            link: function (scope) {
                scope.handleAdd = function ($file) {
                    if ($file.size > 2048000) {
                        alert('Масимальный размер файла 2 бм');

                        return false;
                    }
                    return true;
                }
            }
        }
    });

    /**
     * advertsForm
     */
    app.directive("advertsForm", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/app/parts/adverts/advertsFormDirective.html"
        }
    });
}(window));