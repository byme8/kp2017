using System;
using System.Linq;
using kp.Entities.Data;

namespace kp.Business.Abstractions.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        bool Exist(Guid id);

        void Remove(Guid id);

        TEntity Get(Guid id);

        IQueryable<TEntity> Get();

        void SaveChanges();
    }
}