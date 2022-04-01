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
        /*
            ѕримечание к заданию lession2_2_1, lession2_2_2.

        “ак получилось, что € сделал сразу 2 задани€, т.к. пыталс€ адаптировать задачу под свой проект
        ¬ моем проекте должно быть 2 типа товара, это товар и услуги, причем, услуги должны расчитыватьс€ по заданному алгоритму
          сожалению функционал услуг € не успел добавить
        –ешил добавить только функционал товаров, буз услуг
        ƒобавил возможность сохранени€ (https://localhost:5001/product/save) и чтени€ json. 
        ¬озможность добавлени€ новых товаров через параметры например https://localhost:5001/product/AddProduct?name=59-70&cost=32000  
         */

        public static void Main(string[] args)
        {
            // в данном месте находитс€ конфигураци€ веб приложени€, котора€ както конфигурируетс€, строитс€ и запускаетс€
            CreateHostBuilder(args).Build().Run(); // »з того, что вернул CreateHostBuilder мы вызываем Build(),
                                                   // который возвращает сам хост, и потом мы этот хост запускаем.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) // метод, который возвращает IHostBuilder. јбстракци€, котора€ умеет строить хост,
                                                                    // который слушает какие-то запросы в по сети интернет
            {                                                                     
                return Host.CreateDefaultBuilder(args) // конфигурируютс€ стандартные настройки
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>(); // происходит вторична€ или стартова€ настройка запросов, которые наход€тс€ в классе Startup
                    });
            }
    }
}
