using System;
using System.ComponentModel.DataAnnotations;

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