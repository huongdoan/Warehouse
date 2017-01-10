﻿using SuiteSolution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuiteSolution.WebAPI.Controllers
{

    [RoutePrefix("api/Export")]
    public class ProductExportController : ApiController
    {

        private readonly IProductExportService _productExportService;

        public ProductExportController(IProductExportService productService)
        {
            _productExportService = productService;
        }


        // GET: api/ProductExport
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
