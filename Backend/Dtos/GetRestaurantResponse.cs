using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Dtos
{
    public class GetRestaurantResponse
    {
        public GetRestaurantResponse(Restaurant restaurant)
        {
            RestaurantId = restaurant.RestaurantId;
            Name = restaurant.Name;
            Rating = restaurant.Rating;
        }
        public int RestaurantId { get; set; }
        public string Name { get; set; } = default!;
        public int? Rating { get; set; }
    }
}