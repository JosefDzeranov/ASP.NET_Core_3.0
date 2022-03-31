using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        public string Index(double a, double b, string c)
        {
            switch (c)
            {
                case null:
                case "+": return $"{a}+{b}={a + b}";
                case "-": return $"{a}-{b}={a - b}";
                case "*": return $"{a}-{b}={a - b}";
                case "/": return b != 0 ? $"{a}/{b}={a / b}":"Делить на ноль нельзя.";
                             // if true ? result 1          : otherwise result 2;

                default:

                    return "Вы неправильно передали операцию. Можно передавать только +, -, *.";
            }
        }
    }
}
