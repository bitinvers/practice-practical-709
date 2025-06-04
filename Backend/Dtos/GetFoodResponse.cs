using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Dtos
{
    public class GetFoodResponse
    {
        public GetFoodResponse(Food food)
        {
            FoodId = food.FoodId;
            Name = food.Name;
            Description = food.Description;
            Restaurant = new GetRestaurantResponse(food.Restaurant!);
        }
        public int FoodId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public GetRestaurantResponse Restaurant { get; set; } = default!;
    }
}