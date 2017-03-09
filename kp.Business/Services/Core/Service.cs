using System;
using System.Collections.Generic;
using System.Text;
using kp.Business.Abstractions;
using kp.Domain.Data.Core;

namespace kp.Business.Services.Core
{
	class Service<TDomainEntity> : IService<TDomainEntity>
		where TDomainEntity : DomainEntity
	{
		public Service()
		{
			this.Entities = new List<TDomainEntity>();
		}

		public List<TDomainEntity> Entities
		{
			get;
		}

		public virtual TDomainEntity Add(TDomainEntity entity)
		{
			this.Entities.Add(entity);

			return entity;
		}

		public virtual void Remove(TDomainEntity entity)
		{
			this.Entities.Remove(entity);
		}

		public virtual void Update(TDomainEntity entity)
		{
			var index = this.Entities.FindIndex(o => o.Id == entity.Id);
			this.Entities[index] = entity;
		}
	}
}
