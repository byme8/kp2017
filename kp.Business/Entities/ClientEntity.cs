using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class ClientEntity : Entity
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public IList<PaymentEntity> Payments
        {
            get;
            set;
        } = new List<PaymentEntity>();
    }
}
