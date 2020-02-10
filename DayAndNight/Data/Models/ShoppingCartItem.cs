using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }

        public Drink Drink { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
