using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using kp.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers
{
    [OnlyAdmins]
    [Route("api/paymentKinds")]
    public class PaymentKindController : EntityController<PaymentKind>
    {
        public PaymentKindController(IEntityService<PaymentKind> entities) 
            : base(entities)
        {
        }
    }
}
