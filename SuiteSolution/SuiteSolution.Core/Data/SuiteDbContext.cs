using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace SuiteSolution.Core.Data
{
    public class SuiteDbContext : DbContext
    {
        public SuiteDbContext() : base("name=SuiteDbContext")
        {
            Database.SetInitializer<SuiteDbContext>(null);
        }
        public IDbSet<ProductExport> ProductExports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }



    }
}