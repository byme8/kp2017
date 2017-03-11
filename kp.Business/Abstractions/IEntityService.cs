using System.Linq;
using kp.Domain.Data.Core;

namespace kp.Business.Abstractions
{
	public interface IEntityService<TEntity>
		where TEntity : DomainEntity
	{
		TEntity Add(TEntity entity);
		void Remove(TEntity entity);

		IQueryable<TEntity> Get();
    }
}
