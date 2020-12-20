using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Landlord_project.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region Fields
        protected readonly DataContext _context;
        #endregion

        #region Constructor
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>();
                return includes.Aggregate(query.AsQueryable(), (query, path) => query.Include(path));
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public T GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>();
                return includes.Aggregate(query.AsQueryable(), (query, path) => query.Include(path)).FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        #endregion
    }
}
