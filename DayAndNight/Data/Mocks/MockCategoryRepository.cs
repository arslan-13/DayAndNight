using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Alcoholic",CategoryDescription="All Alcoholic"},
                    new Category{CategoryName="Non-Alcoholic",CategoryDescription="All Non-Alcoholic"}
                };
            }
        }
    }
}
