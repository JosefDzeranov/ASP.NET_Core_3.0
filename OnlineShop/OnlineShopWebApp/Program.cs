using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OnlineShopWebApp
{
    //Произошел конфликт веток.В итоге задание 3.1 "потерялось". Задание 3.1 было выполнено в ветке bilonenko_lesson3_1, которую я слил в данную ветку(т.е.сейчас 2 ветки с заданием 3.2)
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //test
                    webBuilder.UseStartup<Startup>();
                });
    }
}
