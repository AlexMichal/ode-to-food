﻿using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models {
    public class Restaurant { 
        public int Id { get; set; }

        [Display(Name="Restaurant Name:")]
        [DataType(DataType.Text)] // unncessary, but can be useful later for passwords
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Display(Name = "Cuisine Type:")]
        public CuisineType Cuisine { get; set; }
    }
}
