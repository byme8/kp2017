using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kp.Domain.Data;
using kp.Repository.Abstractions;
using kp.Repository.Context;
using kp.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace kp.Repository.Repositories.Core
{
	class Repository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		public DbSet<TEntity> Entities
		{
			get;
		}

		public kpContext Context
		{
			get;
		}

		public Repository(kpContext context)
		{
			this.Context = context;
			this.Entities = context.Set<TEntity>();
		}

		public virtual TEntity Add(TEntity entity)
		{
			return this.Entities.Add(entity).Entity;
		}

		public TEntity Get(Guid id)
		{
			return this.Entities.Single(o => o.Id == id);
		}

		public IQueryable<TEntity> GetAll()
		{
			return this.Entities.AsQueryable();
		}

		public virtual void Remove(TEntity entity)
		{
			this.Entities.Remove(entity);
		}

		public void SaveChanges()
		{
			this.Context.SaveChanges();
		}
	}
}
