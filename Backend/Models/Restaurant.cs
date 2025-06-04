using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; } = default!;
        public int? Rating { get; set; }
        public List<Food> Foods { get; set; } = new();
    }
}