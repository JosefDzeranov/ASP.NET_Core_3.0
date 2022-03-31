using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double  a, double b, string c)
        {
            switch (c)
            {
                case null:
                case "+": return $"{a}+{b}={a + b}";
                case "-": return $"{a}-{b}={a - b}";
                case "*": return $"{a}-{b}={a - b}";
                default:
                    return "Вы неправильно передали операцию. Можно передавать только +, -, *.";
            }
        }

       
    }
}
