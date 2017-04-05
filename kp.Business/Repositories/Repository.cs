using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstractions.Repositories;
using kp.Entities.Data;
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

		public IQueryable<TEntity> Entities
		{
			get;
		}

		public DbSet<TEntity> Set
		{
			get;
		}

		public Repository(kpContext context)
		{
			this.Context = context;
			this.Set = this.Context.Set<TEntity>();
			this.Entities = this.Set;
		}

		public TEntity Add(TEntity entity)
		{
			return this.Set.Add(entity).Entity;
		}

		public void Remove(Guid id)
		{
			var entity = this.Entities.SingleOrDefault(o => o.Id == id);
			if (entity is null)
			{
				throw new InvalidOperationException("Entity missing");
			}

			this.Set.Remove(entity);
		}

		public void SaveChanges()
		{
			this.Context.SaveChanges();
		}

		public TEntity Update(TEntity entity)
		{
			return this.Set.Update(entity).Entity;
		}
	}
}
