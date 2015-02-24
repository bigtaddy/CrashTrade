app.factory('carModelService', ['$resource', 'serviceHelperSvc', function ($resource, serviceHelper) {
    var CarModel = serviceHelper.CarModel;
    var add = function (carModel) {
        //$resource.save will immediately return an object which will have $promise property. 
        //This property will get resolved with values, once the Server returns response
        return CarModel.save(carModel);
    };
    var edit = function (carModel) {
        var updation = CarModel.update(carModel);
        return updation;
    };
    var getById = function (id) {
        return CarModel.get({ carModelId: id });
    };
    var getAll = function () {
        return CarModel.query();
    };
    var deleteById = function (carModelId) {
        return CarModel.delete({ carModelId: carModelId });
    };

    return {
        add: add,
        edit: edit,
        getById: getById,
        getAll: getAll,
        deleteById: deleteById
    };
}]);