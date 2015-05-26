(function(global) {

    'use strict';

    app.controller('HomeCtrl', ['$scope', function ($scope) {
        init();
        function init() {
            loadResources();
        }
        function loadResources() {
           // $scope.resources = resourceSvc.getTopFiveResources();
        }
    }]);

}(window));


