(function () {
    'use strict';

    angular
        .module('suiteApp')
        .service('mainService', mainService);

    mainService.$inject = ['ajaxService'];

    function mainService(ajaxService) {
        this.initializeApplication = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/main/InitializeApplication", successFunction, errorFunction);
        };

        this.authenicateUser = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/main/AuthenicateUser", successFunction, errorFunction);
        };

        this.logout = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/main/Logout", successFunction, errorFunction);
        };
    }
})();