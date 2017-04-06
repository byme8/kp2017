using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Domain.Data.Core;

namespace kp.Domain.Data
{
	public class Role : DomainEntity
	{
		public string Name
		{
			get;
			set;
		}
	}
}
