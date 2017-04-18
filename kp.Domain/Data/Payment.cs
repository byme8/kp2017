using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
    public class Payment : DomainEntity
    {
        public Client Client
        {
            get;
            set;
        }

        public PaymentKind PaymentKind
        {
            get;
            set;
        }

        public decimal Value
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
    }
}
