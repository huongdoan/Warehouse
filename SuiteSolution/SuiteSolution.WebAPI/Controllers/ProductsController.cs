using SuiteSolution.Core.Entities;
using SuiteSolution.Core.Entities.Criteria;
using SuiteSolution.Service;
using SuiteSolution.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuiteSolution.WebAPI.Controllers
{
    
    public class ProductsController : ApiController
    {

        private readonly IProductExportService _productExportService;

        public ProductsController(IProductExportService productExportService)
        {
            _productExportService = productExportService;
        }


        //// GET: api/ProductAPI
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[Route("GetProduct")]
        [HttpGet]
        public HttpResponseMessage GetProducts([FromUri] ProductExportCriteria productInquiryDTO)
        {
            if (productInquiryDTO.SortDirection == null) productInquiryDTO.SortDirection = string.Empty;
            if (productInquiryDTO.SortExpression == null) productInquiryDTO.SortExpression = string.Empty;

            ProductExportApiModel productsWebApiModel = new ProductExportApiModel();
            TransactionalInformation transaction = new TransactionalInformation();
            //ProductsBusinessService productsBusinessService;

            productsWebApiModel.IsAuthenicated = true;

            //var  paging = new DataGridPagingInformation();
            //paging.CurrentPageNumber = productInquiryDTO.CurrentPageNumber;
            //paging.PageSize = productInquiryDTO.PageSize;
            //paging.SortExpression = productInquiryDTO.SortExpression;
            //paging.SortDirection = productInquiryDTO.SortDirection;

            if (productInquiryDTO.SortDirection == "") productInquiryDTO.SortDirection = "ASC";
            if (productInquiryDTO.SortExpression == "") productInquiryDTO.SortExpression = "ProductID";

            //productsBusinessService = new ProductsBusinessService(productsDataService);

            var products = _productExportService.SearchProductExport(productInquiryDTO, out transaction);

            productsWebApiModel.Products = products.Results;
            productsWebApiModel.ReturnStatus = transaction.ReturnStatus;
            productsWebApiModel.ReturnMessage = transaction.ReturnMessage;
            productsWebApiModel.TotalPages = transaction.TotalPages;
            productsWebApiModel.TotalRows = transaction.TotalRows;
            productsWebApiModel.PageSize = productInquiryDTO.PageSize;

            if (transaction.ReturnStatus == true)
            {
                var response = Request.CreateResponse<ProductExportApiModel>(HttpStatusCode.OK, productsWebApiModel);
                return response;
            }

            var badResponse = Request.CreateResponse<ProductExportApiModel>(HttpStatusCode.BadRequest, productsWebApiModel);
            return badResponse;


        }
        // GET: api/ProductAPI/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ProductAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductAPI/5
        public void Delete(int id)
        {
        }
    }
}
