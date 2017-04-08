using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using kp.WebApi.Filters;

namespace kp.Controllers
{
    [OnlyAdmins]
	[Route("api/users")]
	public class UserController : EntityController<User>
	{
		public UserController(IUserService entities)
			: base(entities)
		{
			this.Users = entities;
		}

		public IUserService Users
		{
			get;
		}

		[HttpPost("{userId}/roles/{roleId}")]
		public User AddRole(Guid userId, Guid roleId)
		{
			return this.Users.AddRole(userId, roleId);
		}
	}
}
