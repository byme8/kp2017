using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Entities.Data;

namespace kp.Business.Entities
{
	[Table("Roles")]
	public class RoleEntity : Entity
	{
		public string Name
		{
			get;
			set;
		}
	}
}
