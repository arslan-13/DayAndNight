using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DayAndNigthDbContext context;
        public CategoryRepository(DayAndNigthDbContext dayAndNigthDbContext)
        {
            context = dayAndNigthDbContext;
        }
        public IEnumerable<Category> Categories => context.tblcategories;
    }
}
