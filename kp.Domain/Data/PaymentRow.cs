using System;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
    public class PaymentRow : DomainEntity
    {
        public Client Client
        {
            get;
            set;
        }

        public decimal Value
        {
            get;
            set;
        }

        public PaymentKind PaymentKind
        {
            get;
            set;
        }

        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }
    }
}