using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kp.Entities.Data
{
	public class Entity
	{
		[Key]
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
