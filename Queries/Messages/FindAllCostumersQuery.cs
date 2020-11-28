using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Queries.Messages
{
    public class FindAllCostumersQuery : IRequest<IList<CustomerDTO>>
    {
        public string Name { get; set; } 
        public int? GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public int? ClassificationId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LastPurchaseStart { get; set; }
        public DateTime? LastPurchaseEnd { get; set; }
    }
}
