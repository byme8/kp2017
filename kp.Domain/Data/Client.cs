using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
    public class Client : DomainEntity
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

        public string Email
        {
            get;
            set;
        }

        public List<Payment> Payments
        {
            get;
            set;
        } = new List<Payment>();
    }
}
