using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models
{
    public class Gear
    {
        [Key]
        public int GearId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Make { get; set; }

        [Required]
        [StringLength(255)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Image URL")]
        public string ImagePath { get; set; }

        public double Value { get; set; }

        [Display(Name = "Rental Price")]
        public double RentalPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public bool Insurance { get; set; }

        [Required]
        public bool Rentable { get; set; }

        public bool Rented { get; set; }
    }
}
