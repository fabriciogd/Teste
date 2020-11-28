using Domain.Core.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Region")]
    public class Region : Entity
    {
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
