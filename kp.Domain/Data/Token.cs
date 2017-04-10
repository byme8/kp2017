using System;
using kp.Domain.Data.Core;

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