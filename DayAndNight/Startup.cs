using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayAndNight.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DayAndNight.Data;
using Microsoft.EntityFrameworkCore;
using DayAndNight.Data.Repository;
using DayAndNight.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DayAndNight
{
   
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DayAndNigthDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ConStrg")));
            services.AddIdentity<IdentityUser, IdentityRole>(/*option => option.SignIn.RequireConfirmedAccount = true*/)
                                .AddEntityFrameworkStores<DayAndNigthDbContext>();

            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

            });

            DbInitializer.Seed(app);
        }
    }
}
