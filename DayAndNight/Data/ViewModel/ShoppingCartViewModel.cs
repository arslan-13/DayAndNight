using DayAndNight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart shoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
