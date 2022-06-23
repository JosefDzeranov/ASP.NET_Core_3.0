using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using Serilog;
using System;

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
            // �������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("online_shop");

            // ��������� �������� DatabaseContext � �������� ������� � ����������
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(connection));

            // ��������� �������� IdentityContext � �������� ������� � ����������
            services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>() //��������� ��� ��������� � ����������� ������������ � ����
                    .AddEntityFrameworkStores<IdentityContext>(); //������������� ��������

            // ��������� ���
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(4);
                options.LoginPath = "/Account/SignIn"; //��������������� ��� �����
                options.LogoutPath = "/Account/SignOut"; //��������������� ��� ������
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true //���� ����������� � ������ �������
                };
            });

            services.AddControllersWithViews();

            services.AddTransient<IProductsStorage, ProductsDbStorage>();

            services.AddTransient<ICartsStorage, CartsDbStorage>();

            services.AddTransient<IOrdersStorage, OrdersDbStorage>();

            services.AddTransient<IFavoriteStorage, FavoriteDbStorage>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //�������������� - ��� ����� �� ���� (����������� ��� ���)
             
            app.UseAuthorization(); //����������� (����� ������������ ����������� - � ����� ������/�����)

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
