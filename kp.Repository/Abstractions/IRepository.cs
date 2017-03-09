using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kp.Repository.Data;

namespace kp.Repository.Abstractions
{
    public interface IRepository<TEntity>
		where TEntity : Entity
    {
		TEntity Add(TEntity entity);

		void Remove(Guid id);
		void Remove(TEntity entity);

		TEntity Get(Guid id);
		IQueryable<TEntity> GetAll();

		void SaveChanges();
	}
}
