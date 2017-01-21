using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuiteSolution.WebAPI.Models
{
    public class ApplicationApiModel : TransactionalInformation
    {
        public List<ApplicationMenu> MenuItems;

        public ApplicationApiModel()
        {
            MenuItems = new List<ApplicationMenu>();
        }
    }
}