﻿using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("City")]
    public class City: ListEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
