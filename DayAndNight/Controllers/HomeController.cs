using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayAndNight.Data.Interfaces;
using DayAndNight.Data.ViewModel;

namespace DayAndNight.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public IActionResult Index()
        {
            var HomeVM = new HomeViewModel
            {
                PerferredDrink = _drinkRepository.PreferredDrinks
            };

            return View(HomeVM);
        }
    }
}