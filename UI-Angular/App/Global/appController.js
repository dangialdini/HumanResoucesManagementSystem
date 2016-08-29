(function () {
    'use strict';
    angular.module('app')
        .controller('MainController', function ($rootScope, $location, $timeout, $filter, appServices, appMenu) {
            var g = $rootScope.general = {};
            var s = $rootScope.services = new appServices($rootScope);
            var m = $rootScope.menu = new appMenu($rootScope);
            console.log("MainController");

            g.asyncEventInProgress = false;
            g.loggedIn = false;

            g.portal = $filter('limitTo')($location.path(), $location.path().length - 2, 1);
            g.portal === '/' ? g.currentView = 'MainMenu' : g.currentView = "Login";



            //$(window).on('beforeunload', function () {
            //    if (g.currentView === 'MainMenu') {
            //        return "You are about to enter the " + g.portalName + " portal."
            //    } else {
            //        return "You are about to navigate away from your current session of Claim Logik " + s.capitaliseString(g.portal) + ". You will lose any unsaved data if you continue.";
            //    }
            //});

            //$(window).resize(function () {
            //    s.resizing();
            //    $timeout.cancel(wait);
            //    wait = $timeout(function () {
            //        s.finishedResizing();
            //    }, 300);
            //});

            //g.notification = {
            //    autoHideAfter: 4000,
            //    position: {
            //        pinned: true,
            //        bottom: 50,
            //        right: 0,
            //        top: null,
            //        left: null
            //    },
            //    animation: {
            //        open: {
            //            effects: "slideIn:left"
            //        },
            //        close: {
            //            effects: "slideIn:left",
            //            reverse: true
            //        }
            //    }
            //};

            var wait;
            window.addEventListener("scroll", function () {
                $timeout.cancel(wait);
                wait = $timeout(function () {
                    g.scrollHeight = window.scrollY;
                }, 300);
            });

            g.backToTop = function () {
                $('html, body').animate({
                    scrollTop: 0
                }, 500);
            };

            //g.showErrors = false;

            //g.infoMessage = '';
            //g.infoPopup = {
            //    title: "Info",
            //    actions: [],
            //    modal: true,
            //    width: 400,
            //    visible: false,
            //    resizable: false,
            //    draggable: false,
            //    autoFocus: false,
            //    open: function () {
            //        $timeout(function () {
            //            $('.infoPopup .focusBtn').focus();
            //        });
            //    }
            //};

            //g.errorMessage = '';
            //g.errorPopup = {
            //    title: "Error",
            //    actions: [],
            //    modal: true,
            //    width: 400,
            //    visible: false,
            //    resizable: false,
            //    draggable: false,
            //    autoFocus: false,
            //    open: function () {
            //        $timeout(function () {
            //            $('.errorPopup .focusBtn').focus();
            //        });
            //    }

            //};

            //g.confirmMessage = "";
            //g.confPopup = {
            //    title: "Confirmation Required",
            //    modal: true,
            //    width: 400,
            //    visible: false,
            //    resizable: false,
            //    draggable: false,
            //    autoFocus: false,
            //    yesFunc: function () { },
            //    noFunc: function () { },
            //    open: function () {
            //        $timeout(function () {
            //            $('.confPopup .focusBtn').focus();
            //        });
            //    }
            //};

            //g.noTabList = [];
            //$('body').on('keydown', function (e) {

            //    var setTabIndex = function (index, element) { $(element).prop('tabIndex', -1); };
            //    if (e.which === 9) {
            //        for (var i = 0; i < g.noTabList.length; i++) {
            //            $(g.noTabList[i]).prop('tabIndex', -1);
            //            $(g.noTabList[i] + ' *').each(setTabIndex);
            //        }
            //    }
            //});

            //g.noTabList.push('banner-menus .noTab');

            //disable the space bar key from scrolling the window
            $(document).keydown(function (e) {
                if (e.which === 32 && e.target === document.body) {
                    return false;
                }
            });


        });
})();