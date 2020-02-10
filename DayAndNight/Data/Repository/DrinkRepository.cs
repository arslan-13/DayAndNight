using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly DayAndNigthDbContext context;
        public DrinkRepository(DayAndNigthDbContext dayAndNigthDbContext)
        {
            context = dayAndNigthDbContext;
        }


        public IEnumerable<Drink> Drinks => context.tblDrinks.Include(c => c.Category);
        public IEnumerable<Drink> PreferredDrinks => context.tblDrinks.Where(p => p.IsPerferredDrink).Include(c => c.Category);

        
        public async Task<Drink> GetDrinkID(int ID)
        {
            return await context.tblDrinks.FindAsync(ID);
        }
    }
}
