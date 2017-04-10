using System.Linq;
using FluentValidation;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Domain.Data;

namespace kp.Business.Validators.Roles
{
    public class NewRoleValidator : AbstractValidator<Role>, INewEntryValidator<Role>
    {
        public NewRoleValidator(IRepository<RoleEntity> roles)
        {
            this.RuleFor(role => role.Name).
                NotEmpty().
                    WithErrorCode(Errors.Errors.RoleShouldHaveName).
                Must(name => roles.Get().All(o => o.Name != name)).
                    WithErrorCode(Errors.Errors.RoleNameShouldBeUnique);
        }
    }
}