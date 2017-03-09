using System;
using System.Collections.Generic;
using System.Text;
using kp.Domain.Data.Core;

namespace kp.Business.Abstractions
{
    public interface IService<TDomainEntity>
		where TDomainEntity : DomainEntity
    {
		TDomainEntity Add(TDomainEntity entity);
		void Update(TDomainEntity entity);
		void Remove(TDomainEntity entity);
    }
}
