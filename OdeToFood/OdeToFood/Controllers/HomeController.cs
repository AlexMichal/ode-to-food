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
    [Authorize] // Ensure the user is authenticated (at controller level: user must be authenticated to use ANY action)
    public class HomeController : Controller {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter) { // getting some objects called IRestaurantData and IGreeter
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        /* Actions */

        // INDEX
        [AllowAnonymous] // Overrides the outer "authorize" attribute
        public IActionResult Index() { // an Action called Index
            var model = new HomeIndexViewModel();

            model.Restaurants = _restaurantData.GetAll();

            //model.CurrentMessage = _greeter.GetMessageOfTheDay(); TODO Remove. Just showing how this works

            return View(model); // Controller will place this information into an object result (or in this case, a view) and 
                                // then something else later in the pipeline will determine what to do with that result.
        }

        // DETAILS of an existing Restaurant
        public IActionResult Details(int id) {
            var model = _restaurantData.Get(id);

            if (model == null) {
                return RedirectToAction(nameof(Index)); // Redirect the user to the Index action. Used nameof instead of "" in case we want to refactor Index()
                //return View("NotFound"); // TODO add a Not Found cshtml VIEW
            }

            return View(model);
        }

        // CREATE a new Restaurant
        [HttpGet] // only if a GET request
        public IActionResult Create() {
            ViewBag.CuisineTypeList = _restaurantData.GetAllCuisineTypes();

            return View(); // Looks for a view named "Create" in /views/shared or /views/home. In this case, it's a form.
        }

        [HttpPost] // only if a POST request
        [ValidateAntiForgeryToken] // need to use this when we authorize users with cookies
        public IActionResult Create(RestaurantEditViewModel model) {
            if (ModelState.IsValid) {
                var newRestaurant = new Restaurant();

                newRestaurant.Name = model.Name;
                newRestaurant.CuisineTypeId = model.CuisineTypeId; // TODO

                newRestaurant = _restaurantData.Add(newRestaurant);

                // Redirect to the newly created restaurant
                return RedirectToAction(nameof(Details), new { id = newRestaurant.RestaurantId, foo = "bar" }); // Can also do foo = "bar" in URL. This is just to show myself how it works
            } else {
                return View();
            }
        }

        // EDIT a Restaurant
        [HttpGet]
        public IActionResult Edit(int id) {
            var model = _restaurantData.Get(id);

            ViewBag.CuisineTypeList = _restaurantData.GetAllCuisineTypes();

            if (model == null) {
                return RedirectToAction(nameof(Index), "Home");
            } else {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Restaurant model) {
            if (ModelState.IsValid) {
                _restaurantData.Update(model);

                return RedirectToAction(nameof(Details), "Home", new { id = model.RestaurantId }); // Redirect to the Index action of the Home controller
            } else {
                return View();
            }
        }
    }
}
