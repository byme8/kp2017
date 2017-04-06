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
		IQueryable<TEntity> Entities
		{
			get;
		}

		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		bool Exist(Guid id);
		void Remove(Guid id);

		void SaveChanges();
	}
}
