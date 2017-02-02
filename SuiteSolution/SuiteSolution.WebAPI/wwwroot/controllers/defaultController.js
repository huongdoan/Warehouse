(function () {
    'use strict';

    angular
        .module('suiteApp')
        .controller('defaultController', defaultController);

    defaultController.$inject = ['$scope', '$rootScope', 'mainService', 'alertsService'];

    function defaultController($scope, $rootScope, mainService, alertsService) {
        $rootScope.closeAlert = alertsService.closeAlert;
        $scope.initializeController = function () {
            mainService.initializeApplication($scope.initializeApplicationComplete, $scope.initializeApplicationError);
        }

        $scope.initializeApplicationComplete = function (response) {
            $rootScope.MenuItems = response.menuItems;
            $rootScope.displayContent = true;

            //if (response.IsAuthenicated == true) {
            //    window.location = "/#/product";
            //}
            //else {

            //    // set timeout needed to prevent AngularJS from raising a digest error
            //    setTimeout(function () {
            //        window.location = "#Accounts/Login";
            //    }, 10);
            //}
        }

        $scope.initializeApplicationError = function (response) {
            alertsService.RenderErrorMessage(response.ReturnMessage);
        }
    }
})();
