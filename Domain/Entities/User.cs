using Domain.Core.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UserSys")]
    public class User : Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
