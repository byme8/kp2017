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
        public Guid PaymentRowId
        {
            get;
            set;
        }

        [ForeignKey(nameof(PaymentRowId))]
        public PaymentRowEntity PaymentRow
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
