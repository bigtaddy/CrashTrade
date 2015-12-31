(function (global) {

    'use strict';

    global.CrashTradeSettings = {
        'baseUrl': '/api/',
        'tokenUrl': '/Token',
        'webUrl': 'http://localhost:9043/',
        'tokenKey': 'CRASH_TRADE.ACCESS_TOKEN',
        'userDataKey': 'CRASH_TRADE.USER_DATA',
        fuelTypes: [{ Id: 1, Name: "Бензин" }, { Id: 2, Name: "Дизель" }],
        transmissionTypes: [{ Id: 1, Name: "Ручная" }, { Id: 2, Name: "Автоматическая" }]
    }
}(window));

