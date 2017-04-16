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
    public class NewPaymentValidator : AbstractValidator<Payment>, INewEntryValidator<Payment>
    {
        public NewPaymentValidator(IRepository<PaymentEntity> payments, IRepository<PaymentKindEntity> paymentKinds, IRepository<ClientEntity> clients)
        {
            this.RuleFor(o => o.Client).
                Must(client => clients.Exist(client.Id));

            this.RuleFor(o => o.PaymentKind).
                Must(paymentKind => paymentKinds.Exist(paymentKind.Id));

            this.RuleFor(o => o).
                Must(payment => payment.PaymentNumber > 0 && 
                     payments.Get().Where(o => o.ClientId == payment.Client.Id && o.PaymentKindId == payment.PaymentKind.Id).
                     All(o => o.PaymentNumber != payment.PaymentNumber));
        }
    }
}
