(function () {
    'use strict';
    angular.module('suiteApp')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider.when('/', {
                templateUrl: '/index.html',
               // requiresLogin: true,
                controller: 'indexController'
            })
          .when('/productExport', {
              templateUrl: '/views/product/productExport.html',
              controller: 'productExportController'
          })
          //.when('/Account/Register', {
          //    templateUrl: '/App/Templates/Account/Register.html',
          //    controller: 'RegisterController'
          //})
          .otherwise({
              redirectTo: '/'
          })
        }])
        .run(checkAuthentication);

    checkAuthentication.$inject = ['$rootScope', '$location', 'tokenHandler'];
    function checkAuthentication($rootScope, $location, tokenHandler) {
        $rootScope.$on('$routeChangeStart', function (event, next, current) {
            var requiresLogin = next.requiresLogin || false;
            if (requiresLogin) {

                var loggedIn = tokenHandler.hasLoginToken();

                if (!loggedIn) {
                    $location.path('/views/account/Login');
                }
            }
        });
    }
})();