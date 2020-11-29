using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Gender")]
    public class Gender : ListEntity
    {
        public ICollection<Customer> Customers { get; set; }
    }
}
