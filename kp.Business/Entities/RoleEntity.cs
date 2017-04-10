using System.ComponentModel.DataAnnotations.Schema;
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