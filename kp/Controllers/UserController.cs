using System;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using kp.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete("{userId}/roles/{roleId}")]
        public User DeleteRole(Guid userId, Guid roleId)
        {
            return this.Users.RemoveRole(userId, roleId);
        }
    }
}