/**
 * Created by a.kravtsov on 9/10/2015.
 */

(function (global) {

    'use strict';

    utilities.directive('advertsSortOptionsDirective', ['entityService', function (entityService) {
        return {
            restrict: 'E',
            scope: {
                sortOptions: "="
            },
            template: '<span class="sort-block">Сортировать по:<span/>' +
            '<select ng-model="sortProperty" data-placeholder="Сортировать по" style=" width: 160px; margin-bottom: 0; display: block;">' +
            '<option value="CreatedOn">Дате Создания</option>' +
            '<option value="Year">Году выпуска</option>' +
            '</select>' +
            '<br />' +
            '<select ng-model="sortOrder" data-placeholder="Порядок сортировки" style="width: 160px; margin-bottom: 0; display: block;">' +
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