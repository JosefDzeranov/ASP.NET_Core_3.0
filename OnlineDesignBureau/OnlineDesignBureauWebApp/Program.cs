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
            Примечание к заданию lession2_2_1, lession2_2_2.
        Так получилось, что я сделал сразу 2 задания, т.к. пытался адаптировать задачу под свой проект и не выделил коммит, когда выполнил задание 1
        В моем проекте должно быть 2 типа товара, это товар и услуги, причем, услуги должны расчитываться по индивидуальному алгоритму.
        Я предполагаю реализовать услуги через класс - генератор, в который вставлять алгоритмы расчета каждой услуги (калькуляторы), написанные отдельно. 
        А так-же в генератор вставлять пакеты с данными (индивидуальными для каждой услуги).
        А этот генератор будет создавать разовый продукт, который ложится в корзину, и удаляется. (Идея понятна? Есть замечания по ней?)
        К сожалению функционал услуг я не успел добавить.
        Решил добавить только функционал товаров, без услуг.
        Добавил возможность сохранения (https://localhost:5001/product/save) и чтения json. 
        Возможность добавления новых товаров через параметры например https://localhost:5001/product/AddProduct?name=59-70&cost=32000  
         */

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
            {                                                                     
                return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
            }
    }
}
