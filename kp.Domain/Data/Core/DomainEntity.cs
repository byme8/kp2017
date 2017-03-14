using System;
using System.Collections.Generic;
using System.Text;

namespace kp.Domain.Data.Core
{
	public class DomainEntity
	{
		public Guid Id
		{
			get;
			set;
		}

		public bool Deleted
		{
			get;
			set;
		}
	}
}
