(function (global) {

    'use strict';

    app.directive('cstDelete', function () {
        return {
            replace: true,

            link: function ($scope, element) {
                console.log(element);
                element.on('click', function () {
                    return global.confirm('Delete item?');
                });
            }
        };
    });

}(window));

