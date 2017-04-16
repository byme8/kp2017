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

namespace kp.Business.Validators.Payments
{
    public class NewPaymentValidator : AbstractValidator<PaymentRow>, INewEntryValidator<PaymentRow>
    {
        public NewPaymentValidator(IRepository<PaymentRowEntity> payments, IRepository<PaymentKindEntity> paymentKinds, IRepository<ClientEntity> clients)
        {
            this.RuleFor(o => o.Client).
                Must(client => clients.Exist(client.Id));

            this.RuleFor(o => o.PaymentKind).
                Must(paymentKind => paymentKinds.Exist(paymentKind.Id));

            //TODO: Thick about rules
            //this.RuleFor(o => o).
            //    Must(payment => payments.Get().Where(o => o.ClientId == payment.Client.Id && o.PaymentKindId == payment.PaymentKind.Id));

            this.RuleFor(o => o).
                Must(paymentKind => paymentKind.StartDate.GetValueOrDefault(DateTime.MinValue) <= paymentKind.EndDate.GetValueOrDefault(DateTime.MaxValue));
        }
    }
}
