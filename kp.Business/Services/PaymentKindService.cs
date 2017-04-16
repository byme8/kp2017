using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Services.Core;
using kp.Domain.Data;

namespace kp.Business.Services
{
    public class PaymentKindService : EntityService<PaymentKind, PaymentKindEntity>, IEntityService<PaymentKind>
    {
        public PaymentKindService(IRepository<PaymentKindEntity> entities, INewEntryValidator<PaymentKind> newEntryValidator) 
            : base(entities, newEntryValidator)
        {
        }
    }
}
