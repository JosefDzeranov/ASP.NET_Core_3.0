using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopDB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("online_shop");
            services.AddDbContext<OnlineShopContext>(options =>
            {
               options
              .UseLazyLoadingProxies()
              .UseSqlServer(connection);
            });

            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddControllersWithViews();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository >();
            services.AddTransient<IFavoriteRepository, FavoriteRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]{
                new CultureInfo("en-US")};
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
