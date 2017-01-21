(function () {
    'use strict';

    angular
        .module('suiteApp')
        .controller('indexController', indexController);

    //indexController.$inject = ['$scope', '$rootScope', '$http', '$location', 'blockUI'];

    function indexController($scope, $rootScope, $http, $location, blockUI) {

        $scope.initializeController = function () {

            $scope.aaa = 1+1;
        };
        $scope.$on('$routeChangeStart', function (scope, next, current) {
            if ($rootScope.IsloggedIn == true) {
                $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            }
        });

        $scope.$on('$routeChangeSuccess', function (scope, next, current) {

            setTimeout(function () {
                if ($scope.isCollapsed == true) {
                    set95PercentWidth();
                }
            }, 1000);


        });


        $scope.initializeController = function () {
            $rootScope.displayContent = false;
            if ($location.path() != "") {
                $scope.initializeApplication($scope.initializeApplicationComplete, $scope.initializeApplicationError);
            }
        }

        $scope.initializeApplicationComplete = function (response) {
            $rootScope.MenuItems = response.MenuItems;
            $rootScope.displayContent = true;
            $rootScope.IsloggedIn = true;
        }

        $scope.initializeApplication = function (successFunction, errorFunction) {
            blockUI.start();
            $scope.AjaxGet("/api/main/InitializeApplication", successFunction, errorFunction);
            blockUI.stop();
        };

        $scope.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            $scope.AjaxGetWithData(authenication, "/api/main/AuthenicateUser", successFunction, errorFunction);
        };

        $scope.authenicateUserComplete = function (response) {

            //if (response.IsAuthenicated == false)
            //    window.location = "/index.html";
        }

        $scope.authenicateUserError = function (response) {
            alert("ERROR= " + response.IsAuthenicated);
        }

        $scope.AjaxGet = function (route, successFunction, errorFunction) {
            setTimeout(function () {
                $http({ method: 'GET', url: route }).success(function (response, status, headers, config) {
                    successFunction(response, status);
                }).error(function (response) {
                    errorFunction(response);
                });
            }, 1);

        }

        $scope.AjaxGetWithData = function (data, route, successFunction, errorFunction) {
            setTimeout(function () {
                $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                    successFunction(response, status);
                }).error(function (response) {
                    errorFunction(response);
                });
            }, 1);
        }

        $scope.initializeApplicationError = function (response) {
            alertsService.RenderErrorMessage(response.ReturnMessage);
        }
    }
})();
