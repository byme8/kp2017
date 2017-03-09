﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Entities.Abstractions;
using kp.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace kp.Controllers
{
	[Route("api/users")]
	public class UserController : Controller
	{
		public UserController(IUserService users)
		{
			this.Users = users;
		}

		public IUserService Users
		{
			get;
		}

		[HttpPost]
		public User Create([FromBody]User user)
		{
			return this.Users.Add(user);
		}
	}
}
