using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp
{
    public class Startup // ��� ������ ����� ������ ���������� �������������
    {
        public Startup(IConfiguration configuration) // ����� ���������� IConfiguration �� ����� ���������� � ������������ ����� ����������
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // = ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� ����� � ���������
        
        // ��� ����, ����� ������ ��� �������� ConfigureServices � Configure, � ������ Startup �� ������ ������
        // ��� ���������� ��������� ������� � MVC ���������� (�� Obsidian 4.1 ASP.NET Core MVC - �������� � ������ ������� ���������� �.2)
        // ��� ����� ����� ����������� ��������� ��������
        public void ConfigureServices(IServiceCollection services) // ���� �� ��������� ��� �������, ������� �����,
                                                                   // ����� ��������� ����������� ������ ��������� (Middleware) � �������� �������
        {
            services.AddControllersWithViews(); // ��������� ����������� � �������������, ����� � ����� ������� routingMiddleware
        }

        // = ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //����� ����������, � ����� ������� ��������� ������ ���������
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
              
                // = �������� HSTS �� ��������� ����� 30 ����. ��������, �� �������� �������� ��� ��� ���������������� ���������, ��. https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection(); //��������� HTTP ������ ������������������ � HTTPS ������

            app.UseStaticFiles(); //������������ ������������� ����������� ������ (��� ������������ � ����� wwwroot) ��� ���� js �������, css, �������� � �.�.

            app.UseRouting(); // ��� ���������� ������� �������������, �� ������� ���������, ��� ������ �����, 

            // app.UseAuthorization(); // ��������� ����������� ������������, ��������� ������

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=calculator}/{action=index}/{a?}/{b?}"); 
            });
        }
    }
}
