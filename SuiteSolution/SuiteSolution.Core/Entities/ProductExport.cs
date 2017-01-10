using System;

namespace SuiteSolution.Core.Entities
{
    public class ProductExport : BaseEntity
    {
        public ProductExport():base()
        {
        }
        public string ProductID { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public DateTime ExportDate { get; set; }
        public string Make { get; set; }
        public DateTime Year { get; set; }
        public string Model { get; set; }
    }
}