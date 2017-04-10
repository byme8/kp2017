using System;
using System.Linq;
using kp.Business.Abstractions.Repositories;
using kp.Business.Errors;
using kp.Entities.Data;
using kp.Entities.Exceptions;
using kp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace kp.Business.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        public kpContext Context
        {
            get;
        }

        public DbSet<TEntity> Entities
        {
            get;
        }

        public Repository(kpContext context)
        {
            this.Context = context;
            this.Entities = this.Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return this.Entities.Add(entity).Entity;
        }

        public void Remove(Guid id)
        {
            var entity = this.Entities.SingleOrDefault(o => o.Id == id);
            if (entity is null)
            {
                throw new InvalidOperationException("Entity missing");
            }

            this.Entities.Remove(entity);
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            return this.Entities.Update(entity).Entity;
        }

        public bool Exist(Guid id)
        {
            return this.Entities.Any(o => o.Id == id);
        }

        public TEntity Get(Guid id)
        {
            var entity = this.Entities.FirstOrDefault(o => o.Id == id);
            if (entity is null)
                Error.Throw(Errors.Errors.SuchEntryDoesNotExist, id);

            return entity;
        }

        public IQueryable<TEntity> Get()
        {
            return this.Entities;
        }
    }
}