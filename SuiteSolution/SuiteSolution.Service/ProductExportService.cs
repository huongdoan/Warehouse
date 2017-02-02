using SuiteSolution.Core.Data;
using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuiteSolution.Core.Entities.Criteria;
using SuiteSolution.Core.Entities.SearchResult;
using SuiteSolution.Core;

namespace SuiteSolution.Service
{
    public class ProductExportService : Service<ProductExport, IGenericRepository<ProductExport>>, IProductExportService
    {
        public ProductExportService(IGenericRepository<ProductExport> repository)
            : base(repository)
        {

        }

        public ProductExport CreateExportProduct(ProductExport value, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                //ProductBusinessRules.ValidateProduct(value);

                //if (ProductBusinessRules.ValidationStatus == true)
                //{
                //    Add(value);
                //    transaction.ReturnStatus = true;
                //    transaction.ReturnMessage.Add("Product successfully created.");
                //}
                //else
                //{
                //    transaction.ReturnStatus = ProductBusinessRules.ValidationStatus;
                //    transaction.ReturnMessage = ProductBusinessRules.ValidationMessage;
                //    transaction.ValidationErrors = ProductBusinessRules.ValidationErrors;
                //}
                Add(value);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            finally
            {
            }
            return value;

        }

        public IPagedList<ProductExport> SearchProductExport(ProductExportCriteria productInquiryDTO, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {

                string sortExpression = productInquiryDTO.SortExpression;

                if (productInquiryDTO.SortDirection != string.Empty)
                    sortExpression = sortExpression + " " + productInquiryDTO.SortDirection;

                var productQuery =_repository.Context.ProductExports.AsQueryable();

                productQuery = productQuery.OrderBy(sortExpression);


                return new PagedList<ProductExport>(productQuery, productInquiryDTO.CurrentPageNumber, productInquiryDTO.PageSize);
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }

            return null;
        }
    }
   
}
