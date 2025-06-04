using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AppUser> AppUsers { get; set; } = default!;
    public DbSet<Group> Groups { get; set; } = default!;
    public DbSet<Food> Foods { get; set; } = default!;
    public DbSet<Restaurant> Restaurants { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
      // TODO: Add seed data here
      builder.Entity<Group>().HasData(
        new Group
        {
          GroupId = 1,
          Name = "admin"
        },
        new Group
        {
          GroupId = 2,
          Name = "user"
        }
      );

      builder.Entity<AppUser>().HasData(
        new AppUser
        {
          GroupId = 1,
          AppUserId = 1,
          Username = "admin",
          Password = "admin"
        },
        new AppUser
        {
          GroupId = 2,
          AppUserId = 2,
          Username = "user",
          Password = "user"
        }
      );

      builder.Entity<Restaurant>().HasData(
        new Restaurant
        {
          RestaurantId = 1,
          Name = "KFC",
          Rating = 1
        },
        new Restaurant
        {
          RestaurantId = 2,
          Name = "Dominos",
          Rating = 5
        },
        new Restaurant
        {
          RestaurantId = 3,
          Name = "McDonalds",
          Rating = 3
        }
      );

      builder.Entity<Food>().HasData(
        new Food
        {
          FoodId = 1,
          RestaurantId = 1,
          Name = "Double Down",
          Description = "It's back! (Original)"
        },
        new Food
        {
          FoodId = 2,
          RestaurantId = 2,
          Name = "Double Bacon Cheeseburger Pizza",
          Description = "Just go to McDonalds"
        },
        new Food
        {
          FoodId = 3,
          RestaurantId = 3,
          Name = "Big Mac",
          Description = "What more were you expecting?"
        }
      );

      base.OnModelCreating(builder);
    }
  }
}