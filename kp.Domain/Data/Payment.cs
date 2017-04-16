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
        public PaymentRow PaymentRow
        {
            get;
            set;
        }

        public int PaymentNumber
        {
            get;
            set;
        }
    }
}
