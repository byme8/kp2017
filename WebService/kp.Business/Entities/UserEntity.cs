using System;
using System.Collections.Generic;
using System.Text;

namespace kp.Entities.Data
{
	public class UserEntity : Entity
	{
		public string Login
		{
			get;
			set;
		}

		public string PasswordHash
		{
			get;
			set;
		}
	}
}
