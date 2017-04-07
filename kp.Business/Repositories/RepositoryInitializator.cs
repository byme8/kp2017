using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Repositories
{
    public class RepositoryInitializator
    {
        private IUserService users;
        private IEntityService<Role> roles;

        public RepositoryInitializator(IUserService users, IEntityService<Role> roles)
        {
            this.users = users;
            this.roles = roles;
        }

        public void TryInitialize()
        {
            const string DatabaseAdminLogin = "DataBaseAdmin";
            const string DatabaseAdminPassword = "DataBaseAdminPassword";
            const string DatabaseAdminRole = "DatabaseAdmin";

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
