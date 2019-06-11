using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name="Card Type")]
        public string CardType { get; set; }

        [Required]
        [CreditCard]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [StringLength(7)]
        [ExpiryValidation]
        [Display(Name = "Expiration Date MM/yyyy")]
        public string ExpiryDate { get; set; }
    }
}
