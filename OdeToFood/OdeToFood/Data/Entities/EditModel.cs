using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;

namespace OdeToFood.Models {
    [Authorize]
    public class EditModel {
        private IRestaurantData _restaurantData;

        [BindProperty(Name ="None")] // bound information that is coming from an incoming request
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData) {
            _restaurantData = restaurantData;
        }
    }
}