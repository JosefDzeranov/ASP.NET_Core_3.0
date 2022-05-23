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
            services.AddSingleton<IBuyerManager, BuyerManager>();
            services.AddSingleton<IProductManager, ProductManager>();
            services.AddSingleton<IRoleManager, RoleManager>();
            services.AddSingleton<IUserManager, UserManager>();
            services.AddControllersWithViews();
            services.AddScoped<CheckingForAuthorization>();

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
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
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
