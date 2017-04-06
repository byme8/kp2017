using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
	[Table("UserRoles")]
	public class UserRoleEntity : Entity
	{
		public Guid UserId
		{
			get;
			set;
		}

		[ForeignKey(nameof(UserId))]
		public UserEntity User
		{
			get;
			set;
		}

		public Guid RoleId
		{
			get;
			set;
		}

		[ForeignKey(nameof(RoleId))]
		public RoleEntity Role
		{
			get;
			set;
		}
	}
}
