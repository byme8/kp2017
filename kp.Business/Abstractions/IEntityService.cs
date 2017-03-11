using System.Collections.Generic;
using System.Linq;
using kp.Domain.Data.Core;

namespace kp.Business.Abstractions
{
	public interface IEntityService<TEntity>
		where TEntity : DomainEntity
	{
		TEntity Add(TEntity entity);
		void Remove(TEntity entity);
		IEnumerable<TEntity> SaveChanges(IEnumerable<TEntity> entities);

		IQueryable<TEntity> Get();
		IQueryable<TEntity> Get(int page, int size);
	}
}
