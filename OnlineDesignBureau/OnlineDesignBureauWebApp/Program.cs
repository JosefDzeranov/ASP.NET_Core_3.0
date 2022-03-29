using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp
{
    public class Program
    {
        // ссылка на карту сайта и макеты страниц https://drive.google.com/file/d/1-n8R3iTqIGo75zp9-VqaKUVcxneKSALK/view?usp=sharing
        public static void Main(string[] args)
        {
            // в данном месте находится конфигурация веб приложения, которая както конфигурируется, строится и запускается
            CreateHostBuilder(args).Build().Run(); // Из того, что вернул CreateHostBuilder мы вызываем Build(),
                                                   // который возвращает сам хост, и потом мы этот хост запускаем.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) // метод, который возвращает IHostBuilder. Абстракция, которая умеет строить хост,
                                                                    // который слушает какие-то запросы в по сети интернет
            {                                                                     
                return Host.CreateDefaultBuilder(args) // конфигурируются стандартные настройки
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>(); // происходит вторичная или стартовая настройка запросов, которые находятся в классе Startup
                    });
            }
    }
}
