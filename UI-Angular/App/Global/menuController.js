(function () {
    'use strict';
    angular.module('app')
        .directive('mainMenu', function () {
            return {
                restrict: 'E',
                templateUrl: 'App/global/Partials/mainMenu.html?' + (new Date()).getTime(),
                link: function (rootScope) {
                    var g = rootScope.general;
                    var m = rootScope.menu;
                    var s = rootScope.services;
                    
                    g.currentView = 'MainMenu';

                    m.portalMenuObject = [
                        {
                            text: 'Administration',
                            sccClass: 'myClass',
                            summary: 'The admin portal is here for all your admin needs...',
                            icon: 'fa-users'
                        },
                        {
                            text: 'Development',
                            sccClass: 'myClass',
                            summary: 'The development portal is here for all your admin needs...',
                            icon: 'fa-wrench'
                        },
                        {
                            text: 'Management',
                            sccClass: 'myClass',
                            summary: 'The management portal is here for all your admin needs...',
                            icon: 'fa-user'
                        },
                        {
                            text: 'Sales',
                            sccClass: 'myClass',
                            summary: 'The sales portal is here for all your admin needs...',
                            icon: 'fa-line-chart'
                        },
                        {
                            text: 'Support',
                            sccClass: 'myClass',
                            summary: 'The support portal is here for all your admin needs...',
                            icon: 'fa-life-ring'
                        },
                        {
                            text: 'Training',
                            sccClass: 'myClass',
                            summary: 'The training portal is here for all your admin needs...',
                            icon: 'fa-pencil-square-o'
                        }
                    ]


                }
            }
        })

        .directive('homeView', function ($location) {
            return {
                restrict: 'E',
                templateUrl: 'App/global/Partials/mainMenu.html?' + (new Date()).getTime(),
                controller: function ($rootScope) {
                    var g = $rootScope.general;
                    var m = $rootScope.menu;
                    var s = $rootScope.services;
                    console.log('Menu Controller');
                    g.currentView = 'MenuView';

                    m.bannerMenuOptions = {
                        dataSource: {
                            text: "Menu",
                            items: m.portalMenuObject
                        },
                        select: function (e) {
                            s.navigateAway(function () {
                                var link = $(e.item).find("> span").text();
                                delete g.currentView

                                if (link === "Tools") {
                                    link = 'home';
                                    m.openMenuItem(link)
                                }
                                m.openMenuItem(link);
                            });
                            $rootScope.$apply();
                        },
                    };

                }
            };
        })

        .factory('appMenu', function ($filter, $location, $timeout) {
            function appMenu($rootScope) {
                var m = this;
                var s = $rootScope.services;
                var g = $rootScope.general;
                console.log('appMenu');

                m.buildActionsMenu = function (v) {
                    if (m.actionsMenu === undefined) {
                        m.actionsMenu = [];
                    }
                    if (m.actionsMenu[0] === undefined) {
                        m.actionsMenu[0] = {
                            text: "Actions",
                            items: []
                        };
                    }

                    var menu = [];
                    if (v.actionsArray !== undefined) {
                        for (var i in v.actionsArray) {
                            if (v.actionsArray[i] !== undefined) {
                                menu.push({
                                    text: "<menu-link><i class='fa fa-" +
                                    v.actionsArray[i].icon + "'></i><name>" +
                                    v.actionsArray[i].name + "</name></menu-link>",
                                    encoded: false
                                });
                            }
                        }
                    } else {
                        s.openTechnicalError("The app is trying build an actions menu but the actions array has not been specified");
                    }
                    m.actionsMenu[0].items = menu;
                };

                m.openMenuItem = function (name) {
                    g.asyncEventInProgress = true;
                    //m.bannerMenu.close(); // actions menu not closing when navigating away(possible bug). 

                    var capitalCase = $filter('toCapitalCase')(name)
                    var path = $filter('lowercase')(capitalCase);

                    $timeout(function () {
                        if (g.currentView === 'MainMenu') {
                            g.portalName = $filter('capitalise')(name);
                            window.location = g.portal + path;
                        } else {
                            if (name !== 'home') {
                                g.currentView = $filter('toCamelCase')(name);
                            }
                            $location.path(g.portal + '/' + path);
                        }
                        g.asyncEventInProgress = false;
                    }, 300);
                };

                m.actionsMenuOnSelectGetFunction = function (e, v) {
                    var link = $(e.item).find(">span>menu-link>name").text();

                    if (link !== '') {
                        for (var i = 0; i < v.actionsArray.length; i++) {
                            if (v.actionsArray[i].name === link) {
                                v.actionsArray[i].action();
                                m.buildActionsMenu(v)
                                $rootScope.$apply();
                            }
                        }
                    }
                };

                m.actionsMenuSelect = function (e, m) {
                    var link = $(e.item).find(">span>menu-link>name").text();
                    if (link !== '') {
                        m.actionsMenuObj[link].action();
                        m.buildActionsMenu();
                        $rootScope.$apply();
                    }
                };

            }
            return appMenu
        });
})();