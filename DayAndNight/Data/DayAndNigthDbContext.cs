using DayAndNight.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DayAndNight.Data
{
    public class DayAndNigthDbContext : IdentityDbContext<IdentityUser>    
    {
        public DayAndNigthDbContext(DbContextOptions<DayAndNigthDbContext> options) : base (options)
        {

        }

        public DbSet<Drink> tblDrinks { get; set; }
        public DbSet<Category> tblcategories { get; set; }
        public DbSet<ShoppingCartItem> tblshoppingCartItems { get; set; }

        public DbSet<Order> tblorders { get; set; }
        public DbSet<OrderDetail> tblorderDetails { get; set; }
    }
}
