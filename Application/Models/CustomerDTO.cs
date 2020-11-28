using System;

namespace Application.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ClassificationName { get; set; }
        public string GenderName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public DateTime LastPurchase { get; set; }
        public string UserName { get; set; }
    }
}
