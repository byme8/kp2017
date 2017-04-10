using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
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
    }
}