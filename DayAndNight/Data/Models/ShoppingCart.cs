using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayAndNight.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DayAndNight.Data.Models
{
    public class ShoppingCart
    {
        private readonly DayAndNigthDbContext context;

        public ShoppingCart(DayAndNigthDbContext dayAndNigthDbContext)
        {
            context = dayAndNigthDbContext;
        }
        public string ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<DayAndNigthDbContext>();
            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartID);
            return new ShoppingCart(context) { ShoppingCartID = cartID };
        }

        public void AddToCart(Drink drink,int amount)
        {
            var shoppingCartItem = context.tblshoppingCartItems
                .SingleOrDefault(s => s.Drink.DrinkID == drink.DrinkID && s.ShoppingCartID == ShoppingCartID);

            if(shoppingCartItem==null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ShoppingCartID,
                    Drink = drink,
                    Amount = 1
                };
                context.tblshoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem = context.tblshoppingCartItems
                .SingleOrDefault(s => s.Drink.DrinkID == drink.DrinkID && s.ShoppingCartID == ShoppingCartID);

            var localAmount = 0;

            if (shoppingCartItem!=null)
            {
                if (shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    context.tblshoppingCartItems.Remove(shoppingCartItem);
                }
            }
            context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = context
                .tblshoppingCartItems
                .Where(c => c.ShoppingCartID == ShoppingCartID)
                .Include(s=>s.Drink)
                .ToList());
        }

        public void ClearCart()
        {
            var cartItems = context.tblshoppingCartItems.Where(cart => cart.ShoppingCartID == ShoppingCartID);

            context.tblshoppingCartItems.RemoveRange(cartItems);
            context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = context.tblshoppingCartItems.Where(cart => cart.ShoppingCartID == ShoppingCartID)
                .Select(c => c.Drink.Price * c.Amount).Sum();
            return total;
        }
    }
}
