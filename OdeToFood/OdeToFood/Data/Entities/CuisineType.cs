﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Models {
    [Table("CuisineTypes", Schema = "dbo")]
    public class CuisineType {
        [Key]
        public int CuisineTypeId { get; set; }

        public string Type { get; set; }
    }
}
