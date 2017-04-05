using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Business.Abstractions.Services;
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

		[HttpDelete]
		public void Remove(Guid id)
		{
			this.Users.Remove(id);
		}

		[HttpPut]
		public User Update([FromBody]User user)
		{
			return this.Users.Update(user);
		}

		[HttpGet("{id}")]
		public User Get(Guid id)
		{
			return this.Users.Get().First(o => o.Id == id);
		}

		[HttpGet]
		public IEnumerable<User> Get()
		{
			return this.Users.Get();
		}
	}
}
