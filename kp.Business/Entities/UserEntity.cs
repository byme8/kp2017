using System;
using System.Collections.Generic;
using System.Text;
using kp.Business.Entities;

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

		public IList<UserRoleEntity> Roles
		{
			get;
			set;
		} = new List<UserRoleEntity>();
	}
}
