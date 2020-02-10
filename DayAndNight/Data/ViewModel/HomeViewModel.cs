using DayAndNight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PerferredDrink { get; set; }
    }
}
