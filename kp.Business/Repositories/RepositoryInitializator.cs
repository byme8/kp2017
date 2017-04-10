using System.Linq;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace kp.Business.Repositories
{
    public static class RepositoryInitializator
    {
        public const string DatabaseAdminLogin = "DataBaseAdmin";
        public const string AdminLogin = "Admin";
        private const string Password = "Password";
        public const string DatabaseAdminRole = "DatabaseAdmin";
        public const string AdminRole = "Admin";

        public static void UseRepositoryInitializator(this IApplicationBuilder app)
        {
            var users = app.ApplicationServices.GetService<IUserService>();
            var roles = app.ApplicationServices.GetService<IRoleService>();

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