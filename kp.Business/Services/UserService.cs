using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using kp.Entities.Exceptions;
using kp.Domain.Data;
using kp.Entities.Data;
using AutoMapper;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Services.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using kp.Business.Repositories;

namespace kp.Entities.Services
{
	class UserService : EntityService<User, UserEntity>, IUserService
	{
		public UserService(IRepository<UserEntity> entities,
							INewEntryValidator<User> newEntryValidator,
							IRepository<UserRoleEntity> userRoles,
							IRepository<RoleEntity> roles)
			: base(entities, newEntryValidator)
		{
			this.UserRoles = userRoles;
			this.Roles = roles;
		}

		public IRepository<UserRoleEntity> UserRoles
		{
			get;
		}

		public IRepository<RoleEntity> Roles
		{
			get;
		}

		public User AddRole(Guid userId, Guid roleId)
		{
			if (!this.Repository.Exist(userId))
			{
				throw new BusinessException($"User with id {userId} does not exist");
			}

			if (!this.Roles.Exist(roleId))
			{
				throw new BusinessException($"Role with id {roleId} does not exist");
			}

			this.UserRoles.Add(new UserRoleEntity
			{
				UserId = userId,
				RoleId = roleId
			});
			this.UserRoles.SaveChanges();

			return this.Repository.Get().
				Where(o => o.Id == userId).
					Include(o => o.Roles).
				ProjectTo<User>().First();
		}

		public override IQueryable<User> Get()
		{
			return this.Repository.Get().
				Include(o => o.Roles).
				ProjectTo<User>();
		}

        public bool IsAdmin(Guid userId)
        {
            return HasUserRole(userId, RepositoryInitializator.AdminRole);
        }

        public bool IsDatabaseAdmin(Guid userId)
        {
            return HasUserRole(userId, RepositoryInitializator.DatabaseAdminLogin);
        }

        private bool HasUserRole(Guid userId, string userRole)
        {
            return this.Repository.Get().
                            Any(user => user.Id == userId &&
                                user.Roles.Any(role => role.Role.Name == userRole));
        }
    }
}
