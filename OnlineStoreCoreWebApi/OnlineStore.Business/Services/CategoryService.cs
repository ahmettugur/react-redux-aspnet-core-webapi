using OnlineStore.Business.Contracts;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public Category Add(Category entity)
        {
            return _categoryRepository.Add(entity);
        }


        public int Delete(Category entity)
        {
            return _categoryRepository.Delete(entity);
        }

        public Category Get(Expression<Func<Category, bool>> predicate)
        {
            return _categoryRepository.Get(predicate);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> predicate = null)
        {
            return _categoryRepository.GetAll(predicate);
        }

        public Category Update(Category entity)
        {
            return _categoryRepository.Update(entity);
        }
    }
}
