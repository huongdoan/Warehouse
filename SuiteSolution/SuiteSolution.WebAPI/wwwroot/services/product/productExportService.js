(function() {
    'use strict';

    angular
        .module('suiteApp')
        .service('productExportService', productExportService);

    productExportService.$inject = ['ajaxService'];
    
    function productExportService(ajaxService) {
        this.importProducts = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/ProductExport/ImportProducts", successFunction, errorFunction);
        };

        this.getExportProducts = function (product, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(product, "/api/ProductExport/GetExportProducts", successFunction, errorFunction);
        };

        this.getProductsWithNoBlock = function (product, successFunction, errorFunction) {
            ajaxService.AjaxGetWithNoBlock(product, "/api/ProductExport/GetProducts", successFunction, errorFunction);
        };

        this.createExportProduct = function (product, successFunction, errorFunction) {
            ajaxService.AjaxPost(product, "/api/ProductExport/CreateProduct", successFunction, errorFunction);
        };

        this.updateProduct = function (product, successFunction, errorFunction) {
            ajaxService.AjaxPost(product, "/api/ProductExport/UpdateProduct", successFunction, errorFunction);
        };

        this.getProduct = function (productID, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(productID, "/api/ProductExport/GetProduct", successFunction, errorFunction);
        };
    }

})();