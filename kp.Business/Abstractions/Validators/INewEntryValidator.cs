using kp.Domain.Data.Core;
using kp.Entities.Data;

namespace kp.Business.Abstractions.Validators
{
	public interface INewEntryValidator<TEntity> : IEntityValidator<TEntity>
		where TEntity : DomainEntity
	{
    }
}
