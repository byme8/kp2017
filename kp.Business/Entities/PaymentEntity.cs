using System;
using System.ComponentModel.DataAnnotations.Schema;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class PaymentEntity : Entity
    {
        public Guid UserId
        {
            get;
            set;
        }

        [ForeignKey(nameof(UserId))]
        public ClientEntity Client
        {
            get;
            set;
        }

        public Guid PaymentKindId
        {
            get;
            set;
        }

        [ForeignKey(nameof(PaymentKindId))]
        public PaymentKindEntity PaymentKind
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
