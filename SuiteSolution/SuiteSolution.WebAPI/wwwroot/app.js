(function () {
    'use strict';
    var app = angular.module('suiteApp', [
        // Angular modules 
        'ngRoute',
        'blockUI', 'ngSanitize', 'ui.bootstrap','ui.bootstrap.datetimepicker', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.pagination', 'ui.grid.selection', 'ui.grid.exporter'
        // Custom modules 
        // 3rd Party Modules
    ]);
    app.config(function ($httpProvider) {
        $httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
        $httpProvider.defaults.withCredentials = true;
    });
   
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
})();