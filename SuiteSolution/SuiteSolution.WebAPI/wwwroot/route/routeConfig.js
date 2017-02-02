(function () {
    'use strict';
    angular.module('suiteApp')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider.when('/', {
                templateUrl: '/wwwroot/views/default.html',
               // requiresLogin: true,
                controller: 'defaultController'
            })
            $routeProvider.when('/productexport', {
                templateUrl: '/wwwroot/views/product/productExport.html',
                controller: 'productExportController',
                caseInsensitiveMatch: false
            })
          .otherwise({
              redirectTo: '/'
          })
        }]);
})();