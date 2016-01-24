/**
 * Created by a.kravtsov on 9/10/2015.
 */

(function (global) {

    'use strict';

    utilities.directive('advertsSortOptionsDirective', ['entityService', function (entityService) {
        return {
            restrict: 'E',
            scope: {
                sortOptions: "=",
                withoutPrice: "=?"
            },
            template: '<span>Сортировать по:<span/>' +
            '<select class="form-control input-sm"  ng-model="sortProperty" data-placeholder="Сортировать по"">' +
            '<option value="CreatedOn">Дате Создания</option>' +
            '<option value="Year">Году выпуска</option>' +
            '<option ng-hide="withoutPrice" value="Price">Стоимости</option>' +
            '</select>' +
            '<br />' +
            '<select class="form-control input-sm"  ng-model="sortOrder" data-placeholder="Порядок сортировки">' +
            '<option value="ascending">По возрастанию</option>' +
            '<option value="descending">По убывавнию</option>' +
            '</select>',

            link: function (scope, element, attrs) {
                scope.sortProperty = 'CreatedOn';
                scope.sortOrder = 'descending';

                scope.$watch('sortProperty', function (newValue, oldValue) {
                    if (newValue === oldValue) {
                        return;
                    }

                    scope.sortOptions = newValue + ' ' + scope.sortOrder;
                });

                scope.$watch('sortOrder', function (newValue, oldValue) {
                    if (newValue === oldValue) {
                        return;
                    }

                    scope.sortOptions = scope.sortProperty + ' ' + newValue;
                });
            }
        };
    }]);

}(window));