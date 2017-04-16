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

        public int PaymentNumber
        {
            get;
            set;
        }
    }
}