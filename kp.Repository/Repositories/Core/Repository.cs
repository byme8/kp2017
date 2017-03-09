using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kp.Domain.Data;
using kp.Repository.Abstractions;
using kp.Repository.Data;

namespace kp.Repository.Repositories.Core
{
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		public List<TEntity> Entities
		{
			get;
		}

		public Repository()
		{
			this.Entities = new List<TEntity>();
		}

		public virtual TEntity Add(TEntity entity)
		{
			this.Entities.Add(entity);

			return entity;
		}

		public TEntity Get(Guid id)
		{
			return this.Entities.Single(o => o.Id == id);
		}

		public IQueryable<TEntity> GetAll()
		{
			return this.Entities.AsQueryable();
		}

		public void Remove(Guid id)
		{
			this.Entities.RemoveAll(o => o.Id == id);
		}

		public virtual void Remove(TEntity entity)
		{
			this.Entities.Remove(entity);
		}

		public void SaveChanges()
		{
			
		}
	}
}
