using System;
using System.Linq;
using kp.Domain.Data.Core;

namespace kp.Business.Abstractions.Services
{
    public interface IEntityService<TEntity>
        where TEntity : DomainEntity
    {
        TEntity Add(TEntity entity);

        void Remove(Guid id);

        TEntity Update(TEntity entity);

        IQueryable<TEntity> Get();
    }
}