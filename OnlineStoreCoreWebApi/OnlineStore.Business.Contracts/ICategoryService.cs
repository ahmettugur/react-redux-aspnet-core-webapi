using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Business.Contracts
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> predicate = null);
        Category Get(Expression<Func<Category, bool>> predicate);
        Category Add(Category entity);
        Category Update(Category entity);
        int Delete(Category entity);
    }
}
