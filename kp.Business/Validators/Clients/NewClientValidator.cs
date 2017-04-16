using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Domain.Data;

namespace kp.Business.Validators.Clients
{
    public class NewClientValidator : AbstractValidator<Client>, INewEntryValidator<Client>
    {
        public NewClientValidator(IRepository<ClientEntity> clients)
        {
            this.RuleFor(o => o.FirstName).
                NotEmpty();
            this.RuleFor(o => o.LastName).
                NotEmpty();
            this.RuleFor(o => o.Email).
                NotEmpty();
        }
    }
}
