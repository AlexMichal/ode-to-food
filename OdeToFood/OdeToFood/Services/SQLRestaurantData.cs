using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services {
    public class SQLRestaurantData : IRestaurantData {
        private OdeToFoodDbContext _context;

        public SQLRestaurantData(OdeToFoodDbContext context) {
            _context = context;
        }

        public Restaurant Add(Restaurant newRestaurant) {
            _context.Restaurants.Add(newRestaurant); // A brand new entity that we need to insert.
            _context.SaveChanges(); // Changes dont occur until this command is called. starts May want to have this in a diff method called SaveChanges, or Commit, or something

            return newRestaurant;
        }

        public Restaurant Get(int id) {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll() {
           return  _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant restaurant) {
            _context.Attach(restaurant).State = EntityState.Modified; // 
            _context.SaveChanges();

            return restaurant;
        }
    }
}
