using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inGear.Models.ViewModels
{
    public class MyOrdersVM
    {
        public Order Order { get; set; }
        public virtual List<Order> OpenOrders { get; set; }
        public virtual List<Order> ClosedOrders { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Rental Income Pending")]
        public double OpenOrdersTotal { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Rental Income Earned")]
        public double ClosedOrdersTotal { get; set; }
    }
}
