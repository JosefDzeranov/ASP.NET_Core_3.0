using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopWebApp.Services;
using Serilog;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.db;
using IOrdersRepository = OnlineShop.db.IOrdersRepository;
using OnlineShop.db.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Http;


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
            string connection = Configuration.GetConnectionString("online_shop");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection), ServiceLifetime.Singleton);

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                //options.ReturnUrlParameter = "returnUrl";
                options.ExpireTimeSpan = TimeSpan.FromHours(48);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder()
                {
                    IsEssential = true
                };
            });

            services.AddTransient<ICartRepository, CartsDbRepository>();
            services.AddTransient<IProductDataSource, ProductsDbRepository>();
            services.AddTransient<ICustomerProfile, InMemoryCustomerProfile>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            //services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
            services.AddTransient<ImagesProvider>();
            
            services.AddControllersWithViews();

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
            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

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
