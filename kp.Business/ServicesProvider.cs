using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Repositories;
using kp.Business.Services;
using kp.Business.Services.Core;
using kp.Business.Validators.Roles;
using kp.Business.Validators.Users;
using kp.Domain.Data;
using kp.Entities.Services;
using kp.Repositories.Context;
using Microsoft.Extensions.DependencyInjection;

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