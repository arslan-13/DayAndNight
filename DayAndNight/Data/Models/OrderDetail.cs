namespace DayAndNight.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int DrinkID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Drink Drink { get; set; }

        public virtual Order Order { get; set; }

    }
}