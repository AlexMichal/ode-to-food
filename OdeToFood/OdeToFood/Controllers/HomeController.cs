using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// The HomeController receives a request to the root of the application. This will then be instantiated.
namespace OdeToFood.Controllers {
    [Authorize] // ensure the user is authenticated (at controller level: user must be authenticated to use ANY action)
    public class HomeController : Controller {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter) { // getting some objects called IRestaurantData and IGreeter
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        /* Actions */
        [AllowAnonymous] // overrides the outer "authorize" attribute
        public IActionResult Index() { // an Action called Index
            var model = new HomeIndexViewModel();

            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model); // Controller will place this information into an object result (or in this case, a view) and then something else later in the pipeline will determine what to do with that result
        }

        public IActionResult Details(int id) {
            var model = _restaurantData.Get(id);

            if (model == null) {
                return RedirectToAction(nameof(Index)); // redirect the user to the Index action. used nameof instead of "" in case we want to refactor Index()
                //return View("NotFound"); // TODO add a Not Found cshtml VIEW
            }

            return View(model);
        }

        [HttpGet] // only if a GET request
        public IActionResult Create() {
            return View(); // returns a form
        }

        [HttpPost] // only if a POST request
        [ValidateAntiForgeryToken] // need to use this when we authorize users with cookies
        public IActionResult Create(RestaurantEditModel model) {
            if (ModelState.IsValid) {
                var newRestaurant = new Restaurant();

                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id, foo = "bar" }); // foo = "bar" just to show myself how it works
            } else {
                return View();
            }
        }

        public IActionResult Edit() {
            return View();
        }
    }
}
