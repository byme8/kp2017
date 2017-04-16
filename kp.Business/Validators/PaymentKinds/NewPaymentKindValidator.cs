using System;
using System.Linq;
using FluentValidation;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Domain.Data;

namespace kp.Business.Validators.PaymentKinds
{
    public class NewPaymentKindValidator : AbstractValidator<PaymentKind>, INewEntryValidator<PaymentKind>
    {
        public NewPaymentKindValidator(IRepository<PaymentKindEntity> paymentKinds)
        {
            this.RuleFor(o => o.Name).
                Must(name => paymentKinds.Get().All(o => o.Name != name));

            this.RuleFor(o => o).
                Must(paymentKind => paymentKind.StartDate.GetValueOrDefault(DateTime.MinValue) <= paymentKind.EndDate.GetValueOrDefault(DateTime.MaxValue));
        }
    }
}
