(function (global) {

    'use strict';

    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function(searchString, position) {
            position = position || 0;
            return this.indexOf(searchString, position) === position;
        };
    }

    global.CrashTradeSettings = {
        'baseUrl': '/api/',
        'tokenUrl': '/Token',
        'webUrl': 'http://localhost:9043/',
        'tokenKey': 'CRASH_TRADE.ACCESS_TOKEN',
        'userDataKey': 'CRASH_TRADE.USER_DATA',
        fuelTypes: [{ Id: 1, Name: "Бензин" }, { Id: 2, Name: "Дизель" }],
        transmissionTypes: [{ Id: 1, Name: "Ручная" }, { Id: 2, Name: "Автоматическая" }],
        years: fetYears()
    }

    /**
     * fetYears
     * @returns {Array}
     */
    function fetYears(){
        var years = [];
        var year = new Date().getFullYear();
        while(year > 1960){
            years[years.length] = year;
            year --;
        }

        return years;
    }
}(window));

