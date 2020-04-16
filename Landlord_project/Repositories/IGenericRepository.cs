using Landlord_project.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Landlord_project.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
