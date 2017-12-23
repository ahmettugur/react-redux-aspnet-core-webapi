using OnlineStore.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Core.Contracts.Repository
{
    public interface IGenericRepository<T>
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);

    }
}
