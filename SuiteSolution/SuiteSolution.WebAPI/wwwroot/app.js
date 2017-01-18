(function () {
    'use strict';

    var app = angular.module('suiteApp', [
        // Angular modules 
        'ngRoute',
        'blockUI', 'ngSanitize', 'ui.bootstrap', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.pagination', 'ui.grid.selection', 'ui.grid.exporter'
        // Custom modules 
        // 3rd Party Modules
    ]);

    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('xmlHttpInteceptor');
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
    }]);
    function errorHandler(status, message) {
        var scope = angular.element($('html')).scope();
        scope.errorHandler(status, message);
    };
    app.config(function (blockUIConfig) {

        // Change the default overlay message
        blockUIConfig.message = 'Please stop clicking!';
        // Change the default delay to 100ms before the blocking is visible
        blockUIConfig.delay = 100;
        // Disable automatically blocking of the user interface
        blockUIConfig.autoBlock = false;

    });

    //app.config(['$routeProvider', function ($routeProvider) {
    //    $routeProvider
    //    .when('/', {
    //        templateUrl: 'index.htm', controller: 'indexController'
    //    })
    //    .when('/:section/:tree', {
    //        templateUrl: function (rp) { return 'views/' + rp.section + '/' + rp.tree + '.html'; },
    //        resolve: {

    //            load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {

    //                var path = $location.path();
    //                var parsePath = path.split("/");
    //                var parentPath = parsePath[1];
    //                var controllerName = parsePath[2];

    //                var loadController = "controllers/" + controllerName + "Controller";

    //                var deferred = $q.defer();
    //                require([loadController], function () {
    //                    $rootScope.$apply(function () {
    //                        deferred.resolve();
    //                    });
    //                });
    //                return deferred.promise;
    //            }]
    //        }
    //    })
    //    .when("/:section/:tree/:id", {
    //        templateUrl: function (rp) { return 'views/' + rp.section + '/' + rp.tree + '.html'; },
    //        resolve: {

    //            load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {

    //                var path = $location.path();
    //                var parsePath = path.split("/");
    //                var parentPath = parsePath[1];
    //                var controllerName = parsePath[2];

    //                var loadController = "controllers/" + controllerName + "Controller";

    //                var deferred = $q.defer();
    //                require([loadController], function () {
    //                    $rootScope.$apply(function () {
    //                        deferred.resolve();
    //                    });
    //                });
    //                return deferred.promise;
    //            }]
    //        }
    //    })
    //    .otherwise({
    //        redirectTo: '/'
    //    });

    //}]);





})();