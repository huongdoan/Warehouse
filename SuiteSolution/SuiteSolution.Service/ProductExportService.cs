using SuiteSolution.Core.Data;
using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Service
{
    public class ProductExportService : Service<ProductExport, IGenericRepository<ProductExport>>, IProductExportService
    {
        public ProductExportService(IGenericRepository<ProductExport> repository)
            : base(repository)
        {

        }
    }
   
}
