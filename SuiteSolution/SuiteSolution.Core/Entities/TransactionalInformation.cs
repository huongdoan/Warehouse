using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Core.Entities
{
    public class TransactionalInformation
    {
        public bool ReturnStatus { get; set; }
        public List<string> ReturnMessage { get; set; }
        public Dictionary<string, string> ValidationErrors;
        public int TotalPages;
        public int TotalRows;
        public int PageSize;
        public Boolean IsAuthenicated;
        public string HttpStatusCode;

        public TransactionalInformation()
        {
            ReturnMessage = new List<String>();
            ReturnStatus = true;
            ValidationErrors = new Dictionary<string, string>();
            TotalPages = 0;
            TotalPages = 0;
            PageSize = 0;
            IsAuthenicated = false;
        }
    }
}
