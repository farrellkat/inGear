using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Borrowing From")]
        public string BorrowerId { get; set; }
        public ApplicationUser Borrower { get; set; }

        [Required]
        public string RenterId { get; set; }
        public ApplicationUser Renter { get; set; }

        [Required]
        public int GearId { get; set; }
        public Gear Gear { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        public bool Completed { get; set; }

    }
}
