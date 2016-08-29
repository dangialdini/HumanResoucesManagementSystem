(function () {
    'use strict';
    angular.module('app')
        .directive('banner', function () {
            return {
                restrict: 'E',
                templateUrl: 'App/global/partials/banner.html?' + (new Date()).getTime()
            };
        })

        .directive('portalContainer', function () {
            return {
                restrict: 'E',
                transclude: true,
                templateUrl: 'App/global/partials/portalContainer.html?' + (new Date()).getTime(),
            };
        })

        .directive('actionsMenu', function () {
            return {
                restrict: 'E',
                templateUrl: 'App/global/partials/actionsMenu.html?' + (new Date()).getTime()
            }
        })

        .directive('popupWindowControls', function () {
            return {
                restrict: 'E',
                templateUrl: 'App/global/partials/popupWindowControls.html?' + (new Date()).getTime()
            }
        })


        .directive('imgFallback', function () {
            return {
                link: function (scope, element, attrs) {
                    element.bind('error', function (e) {
                        console.log('(imgFallback): image could not be loaded');
                        attrs.$set('src', 'App/global/images/placeholder.jpg');
                    });

                    attrs.$observe('ngSrc', function (value) {
                        if (!value) {
                            attrs.$set('src', 'App/global/images/placeholder.jpg');
                        }
                    });
                }
            };
        })

})();