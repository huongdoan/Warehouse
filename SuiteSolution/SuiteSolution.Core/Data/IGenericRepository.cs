﻿using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Core.Data
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");
        T GetByID(object id);
        void Insert(T entity);
        void Delete(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        void SaveChanges();

        // Property declaration:
        SuiteDbContext Context
        {
            get;
            set;
        }
    }
}
