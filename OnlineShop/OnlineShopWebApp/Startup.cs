using Domains;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.BL;
using OnlineShop.Db;
using OnlineShop.DB;
using Serilog;
using System;
using Mappers;

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

            services.AddAutoMapper(typeof(MappingProfile));


            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddDbContext<IdentityContext>(options =>
           options.UseSqlite(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Authorization/Authorize";
                options.LogoutPath = "/Authorization/Logout";
                options.Cookie = new CookieBuilder()
                {
                    IsEssential = true
                };
            });

            services.AddTransient<IProductBase, ProductsDBRepository>();
            services.AddTransient<ICartBase,CartsDBRepository>();
            services.AddTransient<IOrderBase, OrdersDBRepository>();
            services.AddTransient<IOrderServicies, OrderServicies>();
            services.AddTransient<ICartServicies, CartServicies>();
            services.AddTransient<IProductServicies, ProductServicies>();




            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
