using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("all")]
        public ActionResult<List<GetFoodResponse>> GetAllFoodItems()
        {
            var foods = _context.Foods.Include(food => food.Restaurant).ToList();
            var response = foods.Select(food => new GetFoodResponse(food)).ToList();
            return response;
        }

        [HttpPost, Route("create")]
        [Authorize("IsAdmin")]
        public ActionResult<bool> CreateFoodItem(CreateFoodRequest request)
        {
            var newFood = request.ConvertToFoodModel();
            _context.Foods.Add(newFood);
            var numRowsChanged = _context.SaveChanges();
            return numRowsChanged == 1;

        }

        //api/Food/delete/1
        [HttpDelete, Route("delete/{id}")]
        [Authorize("IsAdmin")]
        public ActionResult<bool> DeleteFoodItem(int id)
        {
            var foodToDelete = _context.Foods.Find(id);
            if (foodToDelete == null)
            {
                return false;
            }
            _context.Foods.Remove(foodToDelete);
            var numRowsChanged = _context.SaveChanges();
            return numRowsChanged == 1;
        }
    }
}