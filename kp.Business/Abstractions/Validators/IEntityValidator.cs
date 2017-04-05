using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using kp.Domain.Data.Core;

namespace kp.Business.Abstractions.Validators
{
    public interface IEntityValidator<TEntity> 
		where TEntity : DomainEntity
    {
		ValidationResult Validate(TEntity entity);
    }
}
