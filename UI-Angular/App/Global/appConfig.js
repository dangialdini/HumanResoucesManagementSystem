(function () {
    'use strict';
    angular.module('app')
        .config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $locationProvider.html5Mode(true);

            $stateProvider
                .state('main', {
                    url: '/',
                    template: '<main-menu></main-menu>'
                })
                .state('administration', {
                    url: '/administration/',
                    template: '<main-menu></main-menu>'
                })
                .state('development', {
                    url: '/development/',
                    template: '<main-menu></main-menu>'
                })
                .state('management', {
                    url: '/management/',
                    template: '<main-menu></main-menu>'
                })
                .state('sales', {
                    url: '/sales/',
                    template: '<main-menu></main-menu>'
                })
                .state('support', {
                    url: '/support/',
                    template: '<main-menu></main-menu>'
                })
                .state('training', {
                    url: '/training/',
                    template: '<main-menu></main-menu>'
                })

        });
})();