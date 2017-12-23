using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Contracts.Entities;
using OnlineStore.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.Core.Repository.EntityFramework
{
    public abstract class EFGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                return entity;
            }
        }

        public int Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                var result = context.SaveChanges();

                return result;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(predicate);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context= new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }
    }
}
