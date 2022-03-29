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
    public class Startup // все методы этого класса вызываютс€ автоматически
    {
        public Startup(IConfiguration configuration) // через переменную IConfiguration мы можем обращатьс€ к конфигурации всего приложени€
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // = Ётот метод вызываетс€ средой выполнени€. »спользуйте этот метод дл€ добавлени€ служб в контейнер
        
        // ƒл€ того, чтобы пон€ть как работают ConfigureServices и Configure, в классе Startup мы должны пон€ть
        // как происходит обработка запроса в MVC приложении (см Obsidian 4.1 ASP.NET Core MVC - —оздание и разбор шаблона приложени€ п.2)
        // ќни нужны чтобы настраивать обработку запросов
        public void ConfigureServices(IServiceCollection services) // сюда мы добавл€ем все ресурсы, которые нужны,
                                                                   // чтобы создавать необходимые пункты остановки (Middleware) в конвеере запроса
        {
            services.AddControllersWithViews(); // добавл€ем контроллеры и представлени€, чтобы в конце сделать routingMiddleware
        }

        // = Ётот метод вызываетс€ средой выполнени€. »спользуйте этот метод дл€ настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //здесь определ€ем, в каком пор€дке создавать пункты остановки
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
              
                // = «начение HSTS по умолчанию равно 30 дн€м. ¬озможно, вы захотите изменить это дл€ производственных сценариев, см. https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection(); //позвол€ет HTTP запрос переконвертировать в HTTPS запрос

            app.UseStaticFiles(); //обрабатывает использование статических файлов (они расположенны в папке wwwroot) это либо js скрипты, css, картинки и т.п.

            app.UseRouting(); // это добавление шаблона маршрутизации, мы говорим программе, что шаблон будет, 

            // app.UseAuthorization(); // провер€ет авторизацию пользовател€, делающего запрос

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=calculator}/{action=index}/{a?}/{b?}"); 
            });
        }
    }
}
