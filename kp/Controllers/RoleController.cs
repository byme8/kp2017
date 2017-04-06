using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers
{
	[Route("api/user/roles")]
	public class RoleController : EntityController<Role>
	{
		public RoleController(IEntityService<Role> entities) 
			: base(entities)
		{
		}
	}
}
