/**
 * Created by a.kravtsov on 8/12/2015.
 */

/**
 * loadImages
 */
app.directive("loadImages", function () {
    return {
        restrict: "E",
        templateUrl: "/Scripts/app/parts/adverts/loadImagesDirective.html"
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