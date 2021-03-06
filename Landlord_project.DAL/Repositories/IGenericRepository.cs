﻿using Landlord_project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Landlord_project.DAL.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get(params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
