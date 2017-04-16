using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Services.Core;
using kp.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace kp.Business.Services
{
    public class PaymentService : EntityService<PaymentRow, PaymentRowEntity>, IEntityService<PaymentRow>
    {
        public PaymentService(IRepository<PaymentRowEntity> entities, INewEntryValidator<PaymentRow> newEntryValidator) 
            : base(entities, newEntryValidator)
        {
        }

        public override IQueryable<PaymentRow> Get()
        {
            return this.Repository.Get().
                    Include(o => o.Client).
                    Include(o => o.PaymentKind).
                ProjectTo<PaymentRow>();
        }
    }
}
