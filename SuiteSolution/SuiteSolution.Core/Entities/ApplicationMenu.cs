using System;

namespace SuiteSolution.Core.Entities
{
    public class ApplicationMenu
    {
        public Guid MenuId { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string Module { get; set; }
        public int MenuOrder { get; set; }
        public bool RequiresAuthenication { get; set; }
    }
}
