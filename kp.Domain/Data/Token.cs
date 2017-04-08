using kp.Domain.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Domain.Data
{
    public class Token : DomainEntity
    {
        public User User
        {
            get;
            set;
        }

        public DateTime ExpireDate
        {
            get;
            set;
        }
    }
}
