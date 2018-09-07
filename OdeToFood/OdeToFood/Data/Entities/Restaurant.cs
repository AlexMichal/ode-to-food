using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Models {
    public class Restaurant { 
        [Key]
        public int Id { get; set; }

        [Display(Name="Restaurant Name:")]
        [DataType(DataType.Text)] // Unnecessary, but can be useful later for passwords
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Display(Name = "Cuisine Type:")]
        [ForeignKey("CuisineType")]
        public int Cuisine { get; set; }

        //public virtual FacilityMaster Facility { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
