using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.Data {
    public class OdeToFoodDbContext : DbContext {
        public OdeToFoodDbContext(DbContextOptions options) : base(options) {
            // Options specifies which database to connect to
        }

        public DbSet<Restaurant> Restaurants{ get; set; }

        public DbSet<CuisineType> CuisineTypes { get; set; }
    }
}
