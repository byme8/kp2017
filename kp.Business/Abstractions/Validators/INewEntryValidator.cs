using kp.Domain.Data.Core;

namespace kp.Business.Abstractions.Validators
{
	public interface INewEntryValidator<TEntity> : IEntityValidator<TEntity>
		where TEntity : DomainEntity 
    {
    }
}
