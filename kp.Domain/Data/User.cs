﻿using System.Collections.Generic;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
    public class User : DomainEntity
    {
        public string Login
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public List<Role> Roles
        {
            get;
            set;
        } = new List<Role>();
    }
}