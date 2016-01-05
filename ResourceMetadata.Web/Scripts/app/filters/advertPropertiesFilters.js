/**
 * Created by a.kravtsov on 1/5/2016.
 */

(function (global) {

    'use strict';

    app.filter('fuelTypeName', function () {
        return function (input) {
            var fuelTypeName;
            CrashTradeSettings.fuelTypes.every(function(element){
               if(element.Id == input){
                   fuelTypeName = element.Name;
                   return false;
               }
                return true;
            });

            return fuelTypeName;
        };
    });

    app.filter('transmissionTypeName', function () {
        return function (input) {
            var transmissionType;
            CrashTradeSettings.transmissionTypes.every(function(element){
                if(element.Id == input){
                    transmissionType = element.Name;
                    return false;
                }
                return true;
            });

            return transmissionType;
        };
    });

}(window));