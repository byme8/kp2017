using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Domain.Data;
using kp.Entities.Data;

namespace kp.Business.Validators.Users
{
	public class NewUserValidator : AbstractValidator<User>, INewEntryValidator<User>
	{
		public NewUserValidator(IRepository<UserEntity> users)
		{
			this.Users = users;

			this.RuleFor(user => user.Login).
				NotEmpty().
					WithMessage("User should have login.").
				Must(login => this.Users.Entities.All(o => o.Login != login)).
					WithMessage("User's login should be unique.");

			this.RuleFor(user => user.Password).
				NotEmpty().
					WithMessage("User should have password");
		}

		public IRepository<UserEntity> Users
		{
			get;
		}
	}
}
