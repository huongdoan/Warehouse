using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Service
{
    public interface IApplicationDataService
    {
        List<ApplicationMenu> GetMenuItems(Boolean isAuthenicated, out TransactionalInformation transaction);
    }
}
