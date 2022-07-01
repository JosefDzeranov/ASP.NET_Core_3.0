using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineShop.AutomatedUITests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IUsersManager, UsersManager>();
        }
    }
}
