using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
