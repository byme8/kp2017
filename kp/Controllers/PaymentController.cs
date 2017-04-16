using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers
{
    [Route("api/payments")]
    public class PaymentController : EntityController<Payment>
    {
        public PaymentController(IEntityService<Payment> entities) 
            : base(entities)
        {
        }
    }
}
