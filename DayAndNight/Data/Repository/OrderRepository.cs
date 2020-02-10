using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;

namespace DayAndNight.Data.Repository
{
    
    public class OrderRepository : IOrderRepository
    {

        private readonly DayAndNigthDbContext _dayAndNigthDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(DayAndNigthDbContext dayAndNigthDbContext,ShoppingCart shoppingCart)
        {
            _dayAndNigthDbContext = dayAndNigthDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _dayAndNigthDbContext.tblorders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    DrinkID = item.Drink.DrinkID,
                    OrderID = order.OrderID,
                    Price = item.Drink.Price
                };
                _dayAndNigthDbContext.tblorderDetails.Add(orderDetail);
            }

            _dayAndNigthDbContext.SaveChanges();
        }

    }
}
