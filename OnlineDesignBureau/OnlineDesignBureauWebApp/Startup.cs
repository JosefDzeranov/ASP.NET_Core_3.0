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
    public class Startup // все методы этого класса вызываются автоматически
    {
        public Startup(IConfiguration configuration) // через переменную IConfiguration мы можем обращаться к конфигурации всего приложения
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // = Этот метод вызывается средой выполнения. Используйте этот метод для добавления служб в контейнер
        
        // Для того, чтобы понять как работают ConfigureServices и Configure, в классе Startup мы должны понять
        // как происходит обработка запроса в MVC приложении (см Obsidian 4.1 ASP.NET Core MVC - Создание и разбор шаблона приложения п.2)
        // Они нужны чтобы настраивать обработку запросов
        public void ConfigureServices(IServiceCollection services) // сюда мы добавляем все ресурсы, которые нужны,
                                                                   // чтобы создавать необходимые пункты остановки (Middleware) в конвеере запроса
        {
            services.AddControllersWithViews(); // добавляем контроллеры и представления, чтобы в конце сделать routingMiddleware
        }


        // = Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //здесь определяем, в каком порядке создавать пункты остановки
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
              
                // = Значение HSTS по умолчанию равно 30 дням. Возможно, вы захотите изменить это для производственных сценариев, см. https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection(); //позволяет HTTP запрос переконвертировать в HTTPS запрос

            app.UseStaticFiles(); //обрабатывает использование статических файлов (они расположенны в папке wwwroot) это либо js скрипты, css, картинки и т.п.

            app.UseRouting(); // это добавление шаблона маршрутизации, мы говорим программе, что шаблон будет, 

            // app.UseAuthorization(); // проверяет авторизацию пользователя, делающего запрос

            app.UseEndpoints(endpoints => // это правило шаблона Routing
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Start}/{action=Hello}/{id?}"); // вид запроса. Запрос по умолчанию - "{controller=Home}/{action=Index}/{id?}"
                // введеные в паттерне Home и Index - данные по умолчанию, если ничего не будет введено, то водятся эти значения
                /*
                 * если паттерн будет вида
                 * pattern: "{controller=Home}/{action=Index}");
                 * то запрос: http://localhost:5001/hello/start воспримется как controller=hello, action=start
                 * и будет искать в папке controllers файл с названием hello и внутри с метод, который называется start, но такого файла в папке нет, поэтому выведет ошибку
                 * Все контроллеры должны заканчиваться словом Controllers
                 * Поэтому запрос https://localhost:5001/home/index покажет страницу
                 * 
                 * Другой пример. pattern: "{controller=Home}/{action=Index}/{a}/{b}" здесь есть ещё 2 сегмента a, b их может воспринять метод, 
                 * который мы активируем. Например https://localhost:5001/home/index/1/1 для этого в методе можно добавить 2 вводимых параметра 
                 * "public IActionResult Index(int a, int b)" очень важно чтобы названия параметров совпвдвли с названиями сегментов
                 * Можно сегменты сделать опциональными (необязательными) для этого после сегмента надо поставить "?" пример: "{controller=Home}/{action=Index}/{a?}/{b?}"
                 * в этом случае, если сегмента не будет, то параметр будет получать значение по умолчанию
                 */
            });
        }
    }
}
