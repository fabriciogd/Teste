using Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Gender")]
    public class Gender : Entity
    {
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
