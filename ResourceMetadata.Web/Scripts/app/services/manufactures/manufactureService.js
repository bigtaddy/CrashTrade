(function (global) {

    'use strict';

    app.factory('manufactureService', ['$resource', 'serviceHelperSvc', function ($resource, serviceHelper) {
        var Manufacture = serviceHelper.Manufacture;
        var add = function (manufacture) {
            //$resource.save will immediately return an object which will have $promise property.
            //This property will get resolved with values, once the Server returns response
            return Manufacture.save(manufacture);
        };
        var edit = function (manufacture) {
            var updation = Manufacture.update(manufacture);
            return updation;
        };
        var getById = function (id) {
            return Manufacture.get({manufactureId: id});
        };
        var getAll = function () {
            return Manufacture.query();
        };
        var deleteById = function (manufactureId) {
            return Manufacture.delete({manufactureId: manufactureId});
        };

        return {
            add: add,
            edit: edit,
            getById: getById,
            getAll: getAll,
            deleteById: deleteById
        };
    }]);

}(window));

