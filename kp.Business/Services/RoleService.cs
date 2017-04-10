using System;
using System.Linq;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Errors;
using kp.Business.Repositories;
using kp.Business.Services.Core;
using kp.Domain.Data;

namespace kp.Business.Services
{
    public class RoleService : EntityService<Role, RoleEntity>, IRoleService
    {
        public RoleService(IRepository<RoleEntity> entities, INewEntryValidator<Role> newEntryValidator)
            : base(entities, newEntryValidator)
        {
        }

        public override void Remove(Guid id)
        {
            var userName = this.Repository.Get().Where(o => o.Id == id).Select(o => o.Name).First();
            if (userName == RepositoryInitializator.DatabaseAdminRole||
                userName == RepositoryInitializator.AdminRole)
                Error.Throw(Errors.Errors.YouCantDeleteThisRole);

            base.Remove(id);
        }
    }
}