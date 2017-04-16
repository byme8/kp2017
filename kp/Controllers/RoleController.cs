using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using kp.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers
{
    [OnlyAdmins]
    [Route("api/users/roles")]
    public class RoleController : EntityController<Role>
    {
        public RoleController(IRoleService entities)
            : base(entities)
        {
        }
    }
}