using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Dtos
{
    public class CreateFoodRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default;
        public int RestaurantId { get; set; }

        public Food ConvertToFoodModel()
        {
            return new Food
            {
                Name = Name,
                Description = Description,
                RestaurantId = RestaurantId
            };
        }
    }
}