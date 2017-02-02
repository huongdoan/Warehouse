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
using System.Net.Http;

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
            modelBuilder.Entity<ProductExport>().Property(p => p.RowVersion).IsConcurrencyToken();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var currentUsername = !string.IsNullOrEmpty(HttpContext.Current?.User?.Identity?.Name)
           ? HttpContext.Current.User.Identity.Name
           : "Anonymous";

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = (BaseEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;
                    entity.Id = Guid.NewGuid();
                    entity.CreatedBy = currentUsername;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = currentUsername;
                }
            }
            return base.SaveChanges();
        }



    }
}