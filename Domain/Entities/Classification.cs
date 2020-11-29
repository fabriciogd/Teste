using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Classification")]
    public class Classification : ListEntity
    {
        public ICollection<Customer> Customers { get; set; }
    }
}
