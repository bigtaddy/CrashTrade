/**
 * Created by a.kravtsov on 8/12/2015.
 */

/**
 * advertsForm
 */
app.directive("sparePartAdvertForm", function () {
    return {
        restrict: "E",
        templateUrl: "/Scripts/app/parts/sparePartAdverts/sparePartAdvertFormDirective.html",
        link: function (scope, element) {
            scope.validPatternForVIN = new RegExp('^[A-Za-z0-9]{17}$');
        }
    }
});