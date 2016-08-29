(function () {
    'use strict';
    angular.module('app')
        .filter('toCamelCase', function () {
            return function (string) {
                var camelCase = string.replace(/ /g, '');
                camelCase = camelCase.charAt(0).toLowerCase() + camelCase.slice(1);
                return camelCase;
            }
        })

        .filter('toCapitalCase', function () {
            return function (string) {
                return string.replace(/ /g, '');
            }
        })

        .filter('capitalise', function () {
            return function (str) {
                str.replace(/\w\S*/g, function (txt) {
                    return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
                });
                return str
            }
        })

        .filter('yesno', function () {
            return function (yesno) {
                if (yesno === 'Y') {
                    return 'Yes';
                } else if (yesno === 'N') {
                    return 'No';
                } else {
                    console.log('yesno filter was not passed a correct value');
                }
            };
        });

})();