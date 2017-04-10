using System.Linq;
using FluentValidation;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Domain.Data;
using kp.Entities.Data;

namespace kp.Business.Validators.Users
{
    public class NewUserValidator : AbstractValidator<User>, INewEntryValidator<User>
    {
        public NewUserValidator(IRepository<UserEntity> users)
        {
            this.Users = users;
            this.RuleFor(user => user.Login).
                NotEmpty().
                    WithErrorCode(Errors.Errors.UserShouldHaveLogin).
                Must(login => this.Users.Get().All(o => o.Login != login)).
                    WithErrorCode(Errors.Errors.UserLoginExist);

            this.RuleFor(user => user.Password).
                NotEmpty().
                    WithErrorCode(Errors.Errors.UserShouldHavePassword);
        }

        public IRepository<UserEntity> Users
        {
            get;
        }
    }
}