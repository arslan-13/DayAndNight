using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }
        public bool IsPerferredDrink { get; set; }
        public bool Instock { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
}
}
