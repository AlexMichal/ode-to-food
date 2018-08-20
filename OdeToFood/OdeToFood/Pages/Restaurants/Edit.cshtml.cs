﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages.Restaurants
{
    [Authorize]
    public class EditModelx : PageModel
    {
        private IRestaurantData _restaurantData;

        [BindProperty] // bound information that is coming from an incoming request
        public Restaurant Restaurant { get; set; }

        public EditModelx(IRestaurantData restaurantData) {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id) { // id will be in the route/URL
            Restaurant = _restaurantData.Get(id);

            if (Restaurant == null) {
                return RedirectToAction("Index", "Home");
            } else {
                return Page();
            }
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                _restaurantData.Update(Restaurant);

                return RedirectToAction("Details", "Home", new { id = Restaurant.Id });
            } else {
                return Page();
            }
        }
    }
}