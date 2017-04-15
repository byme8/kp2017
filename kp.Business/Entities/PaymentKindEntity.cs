using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public enum PaymentKindPeriod
    {

    }

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
