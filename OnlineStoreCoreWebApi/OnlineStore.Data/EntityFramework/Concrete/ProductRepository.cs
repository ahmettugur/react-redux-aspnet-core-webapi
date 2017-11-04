using OnlineStore.Core.Repository.EntityFramework;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Entity.ComplexType;

namespace OnlineStore.Data.EntityFramework.Concrete
{
    public class ProductRepository : GenericRepository<Product, OnlineStoreContext>, IProductRepository
    {
        public List<ProductWithCategory> GetAllProductWithCategory()
        {
            using (var context = new OnlineStoreContext())
            {
                List<ProductWithCategory> ProductComplex = (from product in context.Products
                                                            join category in context.Categories
                                                            on product.CategoryId equals category.Id
                                                            select new ProductWithCategory
                                                            {
                                                                ProductId = product.Id,
                                                                CategoryId = product.CategoryId,
                                                                Name = product.Name,
                                                                Price = product.Price,
                                                                StockQuantity = product.StockQuantity,
                                                                CategoryName = category.Name,
                                                                Details = product.Details
                                                            }).ToList();

                return ProductComplex;
            }
        }
    }
}
