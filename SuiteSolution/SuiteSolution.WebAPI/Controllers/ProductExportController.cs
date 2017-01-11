using SuiteSolution.Core.Entities;
using SuiteSolution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuiteSolution.WebAPI.Controllers
{
    public class ProductExportController : ApiController
    {

        private readonly IProductExportService _productExportService;
        private readonly ITestService _testService;


        public ProductExportController(IProductExportService productExportService)
        {
            _productExportService = productExportService;
        }

        //public ProductExportController(ITestService testService)
        //{
        //    _testService = testService;
        //}

        // GET: api/ProductExport
        public IEnumerable<ProductExport> Get()
        {
            return _productExportService.Get();
        }

        // GET: api/ProductExport/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductExport
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductExport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductExport/5
        public void Delete(int id)
        {
        }
    }
}
