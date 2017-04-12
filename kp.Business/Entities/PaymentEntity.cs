using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class PaymentEntity : Entity
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
    }
}
