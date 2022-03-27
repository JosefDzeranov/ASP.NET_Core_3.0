using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            if (id != 1 && id != 2 && id != 3)
            {
                return "Такого товара не существует, выберите номер товара от 1 до 3 включительно";
            }
            if (id == 1)
            {
                return "Id1\n100 рублей(Обслуживание)\nДебетовая карта №1\nМолодежная карта. Для тех, кому от 14 лет до 21 года";
            }
            if (id == 2)
            {
                return "Id2\n150 рублей(Обслуживание)\nДебетовая карта №2\nЗолотая карта. Бесплатное обслуживание с подпиской, также по подписке процент на остаток";
            }
            if (id == 3)
            {
                return "Id3\n200 рублей(Обслуживание)\nКредитная карта №1\nПроцетная ставка голодых 20% на покупки, платежи, снятие наличных и переводы";
            }
            return "";
        }
    }
}
