using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using DayAndNight.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository,IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(n => n.DrinkID);
                currentCategory = "All Drinks";
            }
            else
            {
                if (string.Equals("Alcoholic",_category,StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                }
                else
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-Alcoholic")).OrderBy(p => p.Name);
                }

                currentCategory = _category;
            }
            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };
            return View(drinkListViewModel);
        }
    }
}
