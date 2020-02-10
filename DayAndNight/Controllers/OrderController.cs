using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace DayAndNight.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository , ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;
            if (_shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "Your cart is empty,add some drinks first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.checkoutCompleteMessage = "Thanks for you order";
            return View(); 
        }
    }
}