(function (global) {

    'use strict';

    app.controller('HomeCtrl', ['$scope', function () {
        function init() {
            loadResources();
        }

        function loadResources() {
            // $scope.resources = resourceSvc.getTopFiveResources();
        }
        init();
    }]);

}(window));


