using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Domain.Data;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class PaymentKindEntity : Entity
    {
        public string Name
        {
            get;
            set;
        }

        public PaymentKindPeriod Period
        {
            get;
            set;
        }
    }
}
