(function () {
    'use strict';
    angular.module('app')
        .factory('appServices', function ($filter, $timeout, $sce, $compile) {
            function appServices($rootScope) {
                var s = this;
                var d = $rootScope.data;
                var g = $rootScope.general;
                var e = $rootScope.encryptionCode;
                console.log('Services');


                //s.navigateAway = function (func, param) {
                //    g.navContFunc = func;

                //    func();

                //    //if (g.currentView !== 'ToolView') {
                //    //    func();
                //    //    return;
                //    //}

                //    //var catchFunc;
                //    //if ($scope.t.activeSubTool !== undefined) {
                //    //    catchFunc = $scope.t.subTools[$scope.t.activeSubTool].navigateAwayCatch;
                //    //} else {
                //    //    catchFunc = $scope.t.navigateAwayCatch;
                //    //}

                //    //if (catchFunc === undefined) {
                //    //    func(); return;
                //    //}

                //    //catchFunc(param);
                //};

                //s.continueNavigatingAway = function () {
                //    g.navContFunc();
                //};

                s.openTechnicalError = function (error) {
                    s.openErrorPopup("Technical Error", "Apologies, a technical error has occured, we recommend that you restart the application and try again. If this problem persists please don't hesitate to contact ClaimLogik support and we will try to resolve the issue as soon as possible.", error);
                };

                s.openErrorPopup = function (title, msg, error) {
                    g.errorMessage = $sce.trustAsHtml(msg);
                    g.errorTechnical = $sce.trustAsHtml(error);
                    g.errorPopup.title(title);
                    g.errorPopup.center().open();
                };

                s.openInfoPopup = function (title, msg) {
                    g.infoMessage = $sce.trustAsHtml(msg);
                    g.infoPopup.title(title);
                    g.infoPopup.center().open();
                };

                s.openConfPopup = function (title, msg, yesFunc, noFunc) {
                    var resourceObj = { scope: $rootScope, tool: $rootScope.t, timeout: $timeout, sce: $sce, filter: $filter };
                    g.confirmMessage = resourceObj.sce.trustAsHtml(msg);
                    g.confPopup.center().open();
                    g.confPopup.noFunc = function () {
                        g.confPopup.close();
                        if (noFunc !== undefined)
                            noFunc();
                    };
                    g.confPopup.yesFunc = function () {
                        g.confPopup.close();
                        if (yesFunc !== undefined)
                            yesFunc();
                    };
                };

                s.notify = function (msg) {
                    g.notification.show(msg, "info");
                };

            }
            return appServices;
        })
})();