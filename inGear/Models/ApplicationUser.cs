using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Phone]
        public string Phone { get; set; }

        public virtual ICollection<Gear> Gears { get; set; }

        [InverseProperty("UserId")]
        public virtual ICollection<Order> UserOrders { get; set; }
        [InverseProperty("RenterId")]
        public virtual ICollection<Order> RenterOrders { get; set; }

        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
