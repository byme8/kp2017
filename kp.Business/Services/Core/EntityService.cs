using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Errors;
using kp.Domain.Data.Core;
using kp.Entities.Data;
using kp.Entities.Exceptions;

namespace kp.Business.Services.Core
{
    public class EntityService<TDomainEntity, TEntity> : IEntityService<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TEntity : Entity
    {
        public EntityService(IRepository<TEntity> entities, INewEntryValidator<TDomainEntity> newEntryValidator)
        {
            this.Repository = entities;
            this.NewEntryValidator = newEntryValidator;
        }

        public IRepository<TEntity> Repository
        {
            get;
        }

        public INewEntryValidator<TDomainEntity> NewEntryValidator
        {
            get;
        }

        public virtual TDomainEntity Add(TDomainEntity domainEntity)
        {
            var validationResults = this.NewEntryValidator.Validate(domainEntity);
            if (!validationResults.IsValid)
                Error.Throw(validationResults.Errors.Select(o => o.ErrorCode).ToArray());

            var entity = this.Repository.Add(Mapper.Map<TEntity>(domainEntity));

            this.Repository.SaveChanges();

            return Mapper.Map<TDomainEntity>(entity);
        }

        public virtual IQueryable<TDomainEntity> Get()
        {
            return this.Repository.Get().ProjectTo<TDomainEntity>();
        }

        public virtual void Remove(Guid id)
        {
            this.Repository.Remove(id);
            this.Repository.SaveChanges();
        }

        public virtual TDomainEntity Update(TDomainEntity domainEntity)
        {
            var entity = this.Repository.Get().FirstOrDefault(o => o.Id == domainEntity.Id);
            if (entity is null)
                Error.Throw(Errors.Errors.SuchEntryDoesNotExist, domainEntity.Id);

            Mapper.Map(domainEntity, entity);
            this.Repository.SaveChanges();

            return Mapper.Map<TDomainEntity>(entity);
        }
    }
}