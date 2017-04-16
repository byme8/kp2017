using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class PaymentRowEntity : Entity
    {
        public Guid ClientId
        {
            get;
            set;
        }

        [ForeignKey(nameof(ClientId))]
        public ClientEntity Client
        {
            get;
            set;
        }

        public decimal Value
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

        public List<PaymentEntity> Payments
        {
            get;
            set;
        } = new List<PaymentEntity>();
    }
}
