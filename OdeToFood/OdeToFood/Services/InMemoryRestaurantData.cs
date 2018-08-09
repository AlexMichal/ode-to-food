using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services {
    //public class InMemoryRestaurantData : IRestaurantData {
    //    List<Restaurant> _restaurants;

    //    public InMemoryRestaurantData() {
    //        _restaurants = new List<Restaurant> {
    //            new Restaurant { Id = 1, Name ="Sam's place"},
    //            new Restaurant { Id = 2, Name ="Al's place"},
    //            new Restaurant { Id = 3, Name ="Bill's place"}
    //        };
    //    }

    //    public IEnumerable<Restaurant> GetAll() {
    //        return _restaurants.OrderBy(r => r.Name);
    //    }

    //    public Restaurant Get(int id) {
    //        return _restaurants.FirstOrDefault(r => r.Id == id); // a lambda expression
    //    }

    //    public Restaurant Add(Restaurant newRestaurant) {
    //        newRestaurant.Id = _restaurants.Max(r => r.Id) + 1; // go through all of our current restaurants, get the highest id, and add 1
    //        _restaurants.Add(newRestaurant);

    //        return newRestaurant;
    //    }
    //}
}