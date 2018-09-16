using OnlineStore.Business.Contracts;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.ComplexType;
using OnlineStore.Entity.Concrete;
using OnlineStore.MQ.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Business.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private RabbitMQEntityPost<Product> rabbitMQ;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            rabbitMQ = new RabbitMQEntityPost<Product>("ProductQueue");
            
        }

        public Product Add(Product entity)
        {
            return _productRepository.Add(entity);
        }

        public int Delete(Product entity)
        {
            return _productRepository.Delete(entity);
        }

        public Product Get(Expression<Func<Product, bool>> predicate)
        {
            var product = _productRepository.Get(predicate);
            return product;
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> predicate = null)
        {
            return _productRepository.GetAll(predicate);
        }

        public List<ProductWithCategory> GetAllProductWithCategory()
        {
            return _productRepository.GetAllProductWithCategory();
        }

        public Product Update(Product entity)
        {
            var product =  _productRepository.Update(entity);
            rabbitMQ.Post(product);
            return product;
        }
    }
}
