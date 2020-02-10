using DayAndNight.Data.Interfaces;
using DayAndNight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayAndNight.Data.Mocks
{
    public class MockDrinkRepository : IDrinkRepository
    {
        public IEnumerable<Drink> Drinks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<Drink> PreferredDrinks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Drink GetDrinkID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
