using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Models {
    public class Restaurant { 
        [Key]
        public int RestaurantId { get; set; }

        [Display(Name="Restaurant Name:")]
        [DataType(DataType.Text)] // Unnecessary, but can be useful later for passwords
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Display(Name = "Cuisine")]
        [ForeignKey("CuisineType")]
        public int CuisineTypeId { get; set; }
        public virtual CuisineType CuisineType { get; set; } // Reference property

        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
