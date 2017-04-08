using System;
using System.Collections.Generic;
using System.Text;
using kp.Entities.Services;
using kp.Entities;
using Microsoft.Extensions.DependencyInjection;
using kp.Repositories.Context;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Repositories;
using kp.Business.Repositories;
using kp.Domain.Data;
using kp.Business.Abstractions.Validators;
using kp.Business.Validators.Users;
using kp.Business.Services;
using kp.Business.Services.Core;
using kp.Business.Entities;
using kp.Business.Validators.Roles;

namespace kp.Entities
{
    public static class ServicesProvider
    {
		public static void AddBusiness(this IServiceCollection services)
		{
			services.AddDbContext<kpContext>();
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Validators
            services.AddScoped<INewEntryValidator<User>, NewUserValidator>();
			services.AddScoped<INewEntryValidator<Role>, NewRoleValidator>();

			// Services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IEntityService<Role>, EntityService<Role, RoleEntity>>();
		}
    }
}
