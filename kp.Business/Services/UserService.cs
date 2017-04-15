using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Errors;
using kp.Business.Repositories;
using kp.Business.Services.Core;
using kp.Domain.Data;
using kp.Entities.Data;
using kp.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace kp.Entities.Services
{
    internal class UserService : EntityService<User, UserEntity>, IUserService
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
            this.RoleCommandValidation(userId, roleId);

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

        private void RoleCommandValidation(Guid userId, Guid roleId)
        {
            if (!this.Repository.Exist(userId))
                Error.Throw(Errors.SuchEntryDoesNotExist, userId);

            if (!this.Roles.Exist(roleId))
                Error.Throw(Errors.SuchEntryDoesNotExist, roleId);
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
            if (!this.Repository.Exist(userId))
                Error.Throw(Errors.SuchEntryDoesNotExist, userId);

            return this.Repository.Get().
                            Any(user => user.Id == userId &&
                                user.Roles.Any(role => role.Role.Name == userRole));
        }

        public override void Remove(Guid id)
        {
            var userName = this.Repository.Get().Where(o => o.Id == id).Select(o => o.Login).First();
            if (userName == RepositoryInitializator.DatabaseAdminLogin ||
                userName == RepositoryInitializator.AdminLogin)
                Error.Throw(Errors.YouCantDeleteThisUser);

            base.Remove(id);
        }

        public User RemoveRole(Guid userId, Guid roleId)
        {
            this.RoleCommandValidation(userId, roleId);
            var userRole = this.UserRoles.Get().FirstOrDefault(o => o.RoleId == roleId);
            if (userRole is null)
                Error.Throw(Errors.UserDoesNotHaveSuchRole);

            this.UserRoles.Remove(userRole.Id);
            this.UserRoles.SaveChanges();

            return Mapper.Map<User>(this.Repository.Get().First(o => o.Id == userId));
        }
    }
}