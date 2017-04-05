using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Abstractions.Repositories
{
    public interface IRepository<TEntity>
		where TEntity : Entity
	{
		TEntity Add(TEntity entity);
		void Remove(Guid id);

		TEntity Update(TEntity entity);

		IQueryable<TEntity> Entities
		{
			get;
		}

		void SaveChanges();
	}
}
