(function () {
    'use strict';
    angular
        .module('suiteApp')
        .controller('productExportController', productExportController);

    productExportController.$inject = ['$scope', '$rootScope', '$uibModal', 'productExportService', 'alertsService', 'dataGridService'];
    function productExportController($scope, $rootScope, $uibModal, productExportService, alertsService, dataGridService) {

        //For grid
        $scope.gridOptions = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            useExternalPagination: true,
            useExternalSorting: true,
            columnDefs: [
              { name: 'productID' },
              { name: 'exportDate' },
              { name: 'description' },
              { name: 'barCode' },
              { name: 'Action', cellEditableCondition: false, cellTemplate: '<button type="button" class="btn btn-primary btn-sm" ng-click="grid.appScope.EditClick(row)">Edit</button> <button type="button" class="btn btn-primary btn-sm" ng-click="DeleteClick(grid,row)">Delete</button>' }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                    if (sortColumns.length == 0) {
                        paginationOptions.sort = null;
                    } else {
                        paginationOptions.sort = sortColumns[0].sort.direction;
                    }
                    getPage();
                });
                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    getPage();
                });
            }
        };
        var getPage = function () {
            var criteria = {
            };
            productExportService.getExportProducts(criteria, susccessGetPage, failGetPage)
        };
        var susccessGetPage = function (response) {
            alertsService.RenderSuccessMessage(response.returnMessage);
            $scope.gridOptions.totalItems = response.totalRows;
            $scope.gridOptions.data = response.products;
        };

        var failGetPage = function (data) {
        };


        //For Create/Edit
        $scope.animationsEnabled = true;
        $scope.open = function (size, items) {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'productExportModalController',
                size: size,
                resolve: {
                    items: function () {
                        return items;
                    }
                }
            });
            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.EditClick = function (row) {
            $scope.open('lg', row);
        };

        $scope.Delete = function (grid, row) {
        };

        $scope.initializeController = function () {

            $rootScope.applicationModule = "Products";
            $rootScope.alerts = [];

            $scope.ProductID = "";
            $scope.BarCode = "";
            $scope.PageSize = 15;
            $scope.SortDirection = "ASC";
            $scope.SortExpression = "Description";
            $scope.CurrentPageNumber = 1;

            $scope.products = [];


        }



        $scope.searchProducts = function () {
            getPage();
            //$scope.CurrentPageNumber = 1;
            //$scope.getProducts();
        }

        $scope.pageChanged = function () {
            $scope.getProducts();
        }

        $scope.getProducts = function () {
            var productInquiry = $scope.createProductInquiryObject();
            productService.getProducts(productInquiry, $scope.productInquiryCompleted, $scope.productInquiryError);
        }

        $scope.productInquiryError = function (response, status) {
            alertsService.RenderErrorMessage(response.Error);
        }

        $scope.resetSearchFields = function () {
            $scope.ProductCode = "";
            $scope.Description = "";
            $scope.getProducts();
        }




    }



    //productExportModalController
    angular
        .module('suiteApp')
        .controller('productExportModalController', productExportModalController);
    productExportModalController.$inject = ['$scope', '$rootScope', '$routeParams', '$uibModal', '$uibModalInstance', 'productExportService', 'alertsService', 'items'];
    function productExportModalController($scope, $rootScope, $routeParams, $uibModal, $uibModalInstance, productExportService, alertsService, items) {


        $scope.ok = function () {
            //$uibModalInstance.close($scope.selected.item);

        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        //Create Page Session
        $scope.initializeController = function () {

            if (items == "") {
                //For create
                $scope.ProductID = "";
                $scope.BarCode = "";
                $scope.Description = "";
                var date = new Date();
                $scope.ExportDate = new Date(date.getFullYear(), date.getMonth(), date.getDay(), date.getHours(), date.getMinutes());
                $scope.setOriginalValues();
                
            }
            else {
                //for Edit
                var enity = items.entity;
                $scope.ProductID = enity.productID;
                $scope.BarCode = enity.barCode;
                $scope.Description = enity.description;
                var date = new Date();
                $scope.ExportDate = new Date(date.getFullYear(), date.getMonth(), date.getDay(), date.getHours(), date.getMinutes());
                $scope.setOriginalValues();
            }
            $scope.EditMode = true;
            $scope.DisplayMode = false;
            $scope.ShowCreateButton = true;
            $scope.ShowEditButton = false;
            $scope.ShowCancelButton = false;
            $scope.ShowUpdateButton = false;
            //var productId = ($routeParams.Id || "");

            $rootScope.applicationModule = "Products";
            $rootScope.alerts = [];

            //$scope.productId = productId;

            //if (productId == "") {

            //    $scope.ProductID = "";
            //    $scope.BarCode = "";
            //    $scope.Description = "";
            //    var date = new Date();
            //    $scope.ExportDate = new Date(date.getFullYear(),date.getMonth(),date.getDay(),date.getHours(), date.getMinutes());
            //    $scope.setOriginalValues();
            //    $scope.EditMode = true;
            //    $scope.DisplayMode = false;

            //    $scope.ShowCreateButton = true;
            //    $scope.ShowEditButton = false;
            //    $scope.ShowCancelButton = false;
            //    $scope.ShowUpdateButton = false;

            //}
            //else {

            //}

        }

        $scope.setOriginalValues = function () {
            $scope.OriginalProductID = $scope.ProductID;
        }

        $scope.resetValues = function () {
            $scope.Code = $scope.OriginalProductID;
        }

        $scope.cancelChanges = function () {

            $scope.ShowCreateButton = false;
            $scope.ShowEditButton = true;
            $scope.ShowCancelButton = false;
            $scope.ShowUpdateButton = false;
            $scope.EditMode = false;
            $scope.DisplayMode = true;
            $rootScope.alerts = [];

            $scope.resetValues();
        }

        $scope.createExportProduct = function () {
            var product = $scope.createExportProductObject();
            productExportService.createExportProduct(product, $scope.createProductCompleted, $scope.createProductError);
        }

        $scope.createProductCompleted = function (response, status) {

            $scope.EditMode = false;
            $scope.DisplayMode = true;
            $scope.ShowCreateButton = false;
            $scope.ShowEditButton = true;
            $scope.ShowCancelButton = false;

            $scope.ProductId = response.product.Id;
            alertsService.RenderSuccessMessage(response.returnMessage);

            $scope.setOriginalValues();
        }

        $scope.createProductError = function (response) {
            alertsService.RenderErrorMessage(response.returnMessage);
            $scope.clearValidationErrors();
            alertsService.SetValidationErrors($scope, response.ValidationErrors);
        }

        $scope.clearValidationErrors = function () {

            $scope.CodeInputError = false;
            $scope.NameInputError = false;

        }
        $scope.createExportProductObject = function () {
            var product = new Object();
            product.ProductID = $scope.ProductID;
            product.Description = $scope.Description;
            product.BarCode = $scope.BarCode;
            product.ExportDate = $scope.ExportDate;
            return product;
        }

        $scope.initializeController();




    }


})();
