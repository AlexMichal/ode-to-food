using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;


// An Entity framework
namespace OdeToFood.Services {
    public class SQLRestaurantData : IRestaurantData {
        private OdeToFoodDbContext _context;

        // Constructor
        public SQLRestaurantData(OdeToFoodDbContext context) {
            _context = context;
        }

        /* Restaurant */

        public Restaurant Add(Restaurant newRestaurant) {
            _context.Restaurants.Add(newRestaurant); // A brand new entity that we need to insert.
            _context.SaveChanges(); // Changes dont occur until this command is called. May want to have this in a diff method called SaveChanges, or Commit, or something because we may want to batch together multiple changes on a single transaction.

            return newRestaurant;
        }

        public Restaurant Get(int id) {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll() {
            // IEnum not good when quering a large table (10,000+). Instead, use IQueryable
            return  _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant restaurant) {
            _context.Attach(restaurant).State = EntityState.Modified; // 
            _context.SaveChanges();

            return restaurant;
        }

        /* Cuisine */

        public IEnumerable<CuisineType> GetCuisineTypes() {
            return _context.CuisineTypes.ToList();
        }
    }
}
