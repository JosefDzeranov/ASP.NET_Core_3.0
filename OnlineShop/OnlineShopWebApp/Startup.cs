using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopWebApp.Services;
using Serilog;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;


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

            services.AddControllersWithViews();
            //services.AddTransient<ICartRepository, CartsDbRepository>();
            services.AddSingleton<ICartRepository, InMemoryCartRepository>();
            services.AddSingleton<IProductDataSource, ProductsDbRepository>();
            services.AddSingleton<ICustomerProfile, InMemoryCustomerProfile>();
            services.AddSingleton<IOrdersRepository, InMemoryOrdersRepository>();
            services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddSingleton<IUsersManager, UsersManager>();
        
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
