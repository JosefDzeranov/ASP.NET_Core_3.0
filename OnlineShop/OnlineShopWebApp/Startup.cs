using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using Serilog;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Interfase;


namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("online_shop");
            //добавляем контекст DatabaseContext в качестве сервиса в приложение
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<IProductRepository, ProductDbRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
            services.AddTransient<IComparisonRepository, СomparisonDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<IOrdersRepositiry, OrdersDbRepositiry>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IUsersManager, UsersManager>();
            services.AddScoped<CheckingForAuthorization>();
            services.AddControllersWithViews();
            

            services.Configure<RequestLocalizationOptions>(options => //конфигурируем настройки локализации запроса. Решается задача валидации decimal
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSerilogRequestLogging(); //говорит о том, что нужно каждый запрос логировать
            app.UseStaticFiles();
            app.UseRouting();

            //Решается задача валидации decimal
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{roleId?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{roleId?}");
            });
        }
    }
}
