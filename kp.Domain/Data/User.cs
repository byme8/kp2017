using System;
using System.Collections.Generic;
using System.Text;
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
	}
}
