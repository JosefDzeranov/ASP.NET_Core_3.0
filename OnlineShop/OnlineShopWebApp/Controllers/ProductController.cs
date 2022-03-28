using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index()
        {
            return "Id1\n100 рублей(Обслуживание)\nДебетовая карта №1\n\n" +
                "Id2\n150 рублей(Обслуживание)\nДебетовая карта №2\n\n" +
                "Id3\n200 рублей(Обслуживание)\nКредитная карта №1\n\n";
        }
    }
}
