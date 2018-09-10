using OdeToFood.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels {
    public class RestaurantEditViewModel { 
        [Required, MaxLength(80)]
        public string Name { get; set; }

        public int CuisineTypeId { get; set; }
        public virtual CuisineType CuisineType { get; set; } // Reference property
    }
}
