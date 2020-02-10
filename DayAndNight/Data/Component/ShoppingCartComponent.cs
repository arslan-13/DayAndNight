using DayAndNight.Data.Models;
using DayAndNight.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Component
{
    public class ShoppingCartComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
