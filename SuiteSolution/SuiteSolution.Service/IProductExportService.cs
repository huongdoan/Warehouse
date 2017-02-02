using SuiteSolution.Core.Entities;
using SuiteSolution.Core.Entities.Criteria;
using SuiteSolution.Core.Entities.SearchResult;

namespace SuiteSolution.Service
{
    public interface IProductExportService : IService<ProductExport>
    {
        IPagedList<ProductExport> SearchProductExport(ProductExportCriteria productInquiryDTO, out TransactionalInformation transaction);
        ProductExport CreateExportProduct(ProductExport value, out TransactionalInformation transaction);
    }
}