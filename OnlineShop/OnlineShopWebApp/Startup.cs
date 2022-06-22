using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Db;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using Serilog;

namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("online_shop");

            // Добавляем контекст DatabaseContext в качестве сервиса в приложение
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(connection));

            services.AddControllersWithViews();

            services.AddTransient<IProductsStorage, ProductsDbStorage>(); 

            services.AddTransient<ICartsStorage, CartsDbStorage>();

            services.AddTransient<IOrdersStorage, OrdersDbStorage>();

            services.AddTransient<IFavoriteStorage, FavoriteDbStorage>();

            services.AddSingleton<IRoleStorage, RoleStorage>();

            services.AddSingleton<IUserStorage, UserStorage>();

            services.AddControllersWithViews(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
