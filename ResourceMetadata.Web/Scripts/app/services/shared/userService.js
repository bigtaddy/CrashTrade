/**
 * Created by a.kravtsov on 11/27/2015.
 */

(function (global) {

    app.service('UserService', function (localStorageService, $rootScope) {
        var user = {};


        /**
         * User Data
         */
        Object.defineProperty(user, 'data', {
            get: function () {
                return localStorageService.get(global.CrashTradeSettings.userDataKey);
            },
            set: function (user) {
                if (user) {
                    user.isAdmin = (user.Roles.indexOf('Admin') > -1);
                }
                localStorageService.set(global.CrashTradeSettings.userDataKey, user);
                $rootScope.userData = user;
            },
            enumerable: true
        });

        $rootScope.$on('logOff', function () {
            clearUserData();
        });

        /**
         * setUserData
         * @param userData
         */
        function setUserData(userData) {
            user.data = userData;
        }

        /**
         * getUserData
         * @returns {*}
         */
        function getUserData() {
            return user.data;
        }

        /**
         * getRole
         * @returns {string}
         */
        function getRoles() {
            var role = _.get(user.data, 'Roles');

            if (!role) {
                return ['anonymous'];
            }

            return [role];
        }

        /**
         * logout
         */
        function clearUserData() {
            user.data = undefined;
        }

        return {
            getUserData: getUserData,
            getRoles: getRoles,
            setUserData: setUserData,
            clearUserData: clearUserData
        };
    });

}(window));