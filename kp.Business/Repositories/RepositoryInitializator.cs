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
        public const string AdminLogin = "Admin";
        const string Password = "Password";
        public const string DatabaseAdminRole = "DatabaseAdmin";
        public const string AdminRole = "Admin";

        public static void UseRepositoryInitializator(this IApplicationBuilder app)
        {
            var users = app.ApplicationServices.GetService(typeof(IUserService)) as IUserService;
            var roles = app.ApplicationServices.GetService(typeof(IEntityService<Role>)) as IEntityService<Role>;

            if (!users.Get().Any(o => o.Login == DatabaseAdminLogin))
            {
                var user = users.Add(new User
                {
                    Login = DatabaseAdminLogin,
                    Password = Password
                });
                var role = roles.Add(new Role
                {
                    Name = DatabaseAdminRole
                });

                users.AddRole(user.Id, role.Id);

                user = users.Add(new User
                {
                    Login = AdminLogin,
                    Password = Password
                });
                role = roles.Add(new Role
                {
                    Name = AdminRole
                });
                users.AddRole(user.Id, role.Id);
            }
        }
    }
}
