using System;
using System.Collections.Generic;
using System.Linq;
using kp.Business.Abstractions.Services;
using kp.Domain.Data.Core;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers.Core
{
	public class EntityController<TDomainEntity> : Controller
		where TDomainEntity : DomainEntity
	{
		public EntityController(IEntityService<TDomainEntity> entities)
		{
			this.Entities = entities;
		}

		public IEntityService<TDomainEntity> Entities
		{
			get;
		}

		[HttpPost]
		public TDomainEntity Create([FromBody]TDomainEntity user)
		{
			return this.Entities.Add(user);
		}

		[HttpDelete]
		public void Remove(Guid id)  
		{
			this.Entities.Remove(id);
		}

		[HttpPut]
		public TDomainEntity Update([FromBody]TDomainEntity user)
		{
			return this.Entities.Update(user);
		}

		[HttpGet("{id}")]
		public TDomainEntity Get(Guid id)
		{
			return this.Entities.Get().First(o => o.Id == id);
		}

		[HttpGet]
		public IEnumerable<TDomainEntity> Get()
		{
			return this.Entities.Get();
		}
	}
}
