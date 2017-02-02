using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuiteSolution.WebAPI.Models
{

    /// <summary>
    /// Products API Model
    /// </summary>
    public class ProductExportApiModel : TransactionalInformation
    {
        public List<ProductExport> Products;
        public ProductExport Product;

        public ProductExportApiModel()
        {
            Product = new ProductExport();
            Products = new List<ProductExport>();
        }

    }

    /// <summary>
    /// Product DTO
    /// </summary>
    public class ProductExportsDTO
    {
        public Guid ProductID { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }

    }

    public class ProductExportInquiryDTO
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public int CurrentPageNumber { get; set; }
        public string SortExpression { get; set; }
        public string SortDirection { get; set; }
        public int PageSize { get; set; }
    }
}