using SuiteSolution.Core.Data;
using SuiteSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Service
{
    public class Service<T, TRepository> : IService<T>
        where T : BaseEntity
        where TRepository : IGenericRepository<T>
    {
        
        private readonly TRepository _repository;
        

        public Service(TRepository repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            _repository.Insert(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _repository.Insert(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _repository.Delete(entity);
        }
    }
}
