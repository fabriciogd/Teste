using Domain.Core.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UserRole")]
    public class Role : Entity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
