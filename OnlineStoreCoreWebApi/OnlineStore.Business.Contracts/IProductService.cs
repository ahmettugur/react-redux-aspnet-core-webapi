using OnlineStore.Entity.ComplexType;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Business.Contracts
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> predicate = null);
        List<ProductWithCategory> GetAllProductWithCategory();
        Product Get(Expression<Func<Product, bool>> predicate);
        Product Add(Product entity);
        Product Update(Product entity);
        int Delete(Product entity);
    }
}
