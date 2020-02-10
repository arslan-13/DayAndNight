using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using DayAndNight.Data.ViewModel;

namespace DayAndNight.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IDrinkRepository _drinkRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IDrinkRepository drinkRepository, ShoppingCart shoppingCart)
        {
            _drinkRepository = drinkRepository;
            _shoppingCart = shoppingCart;


        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);        
        }

        public RedirectToActionResult AddToShoppingCart(int DrinkID)
        {
            var selectedDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkID == DrinkID);

            if (selectedDrink!=null)
            {
                _shoppingCart.AddToCart(selectedDrink, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int DrinkID)
        {
            var selectDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkID == DrinkID);
            if (selectDrink!=null)
            {
                _shoppingCart.RemoveFromCart(selectDrink);
            }

            return RedirectToAction("index");
        }
    }
}