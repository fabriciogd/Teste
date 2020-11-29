using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Region")]
    public class Region : ListEntity
    {
        public ICollection<Customer> Customers { get; set; }
    }
}
