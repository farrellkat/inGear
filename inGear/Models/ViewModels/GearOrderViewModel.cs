using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models.ViewModels
{
    public class GearOrderViewModel
    {
        public Gear Gear { get; set; }
        public List<Gear> Gears { get; set; }
        public Order Order { get; set; }

        //public ApplicationUser User { get; set; }
    }
}
