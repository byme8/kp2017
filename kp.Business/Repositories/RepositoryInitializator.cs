using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Repositories
{
    public static class RepositoryInitializator
    {
        public const string DatabaseAdminLogin = "DataBaseAdmin";
        const string DatabaseAdminPassword = "DataBaseAdminPassword";
        public const string DatabaseAdminRole = "DatabaseAdmin";

        public static void UseRepositoryInitializator(this IApplicationBuilder app)
        {
            var users = app.ApplicationServices.GetService(typeof(IUserService)) as IUserService;
            var roles = app.ApplicationServices.GetService(typeof(IEntityService<Role>)) as IEntityService<Role>;

            if (!users.Get().Any(o => o.Login == DatabaseAdminLogin))
            {
                var user = users.Add(new User
                {
                    Login = DatabaseAdminLogin,
                    Password = DatabaseAdminPassword
                });
                var role = roles.Add(new Role
                {
                    Name = DatabaseAdminRole
                });

                users.AddRole(user.Id, role.Id);
            }
        }
    }
}
