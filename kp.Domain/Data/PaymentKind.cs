using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
    public enum PaymentKindPeriod
    {
        Day,
        Month,
        Year
    }

    public class PaymentKind : DomainEntity
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
