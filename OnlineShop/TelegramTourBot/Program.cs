using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.db;
using OnlineShop.db.Models;
using Orders;
using TelegramTourBot;

namespace TelegramBotExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            var chat = new ChatBotAPI();
            chat.Init();

            IServiceCollection services = new ServiceCollection();
            string connection = "Server= (localdb)\\mssqllocaldb;Database=online_shop_Iakovleva_7;Trusted_Connection=True;";

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection), ServiceLifetime.Singleton);

            services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<DatabaseContext>();

            services.AddSingleton<IOrdersRepository, OrdersDbRepository>();

            services.AddSingleton<UserDbRepository>();
            services.AddSingleton<OrdersService>();
            services.AddSingleton<TelegramService>();

            var servicesProvider = services.BuildServiceProvider();

            var telegramService = new TelegramService(chat, servicesProvider.GetService<UserDbRepository>(), servicesProvider.GetService<OrdersService>());
            Console.ReadLine();
        }
    }
}