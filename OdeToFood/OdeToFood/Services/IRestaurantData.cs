using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Services {
    public interface IRestaurantData {
        // Restaurant table
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant resturant);

        // CuisineType table
        CuisineType GetCuisineType(int id);
        IEnumerable<CuisineType> GetAllCuisineTypes();
    }
}