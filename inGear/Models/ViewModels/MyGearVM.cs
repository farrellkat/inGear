using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models.ViewModels
{
    public class MyGearVM
    {
        public Gear Gear { get; set; }
        public List<Gear> RentedGear { get; set; }
        public List<Gear> RentableGear { get; set; }
        public List<Gear> NonRentableGear { get; set; }
    }
}
