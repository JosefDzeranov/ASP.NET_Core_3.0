using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double  a, double b, string c)
        {
            return Convert.ToString(Action(a, b, c))??"Вы неправильно передали операцию. Обратитесь в службу поддержки.";
        }

        Func<double, double, double> summ = (a, b) => { return a + b; };
        Func<double, double, double> differece = (a, b) => { return a - b; };
        Func<double, double, double> multiply = (a, b) => { return a * b; };

        public double Action(double a, double b, string c)
        {
            var result = 0.0;

            switch (c)
            {
                case "+":
                    result = summ(a,b);
                    break;
                case "-":
                    result = differece(a,b);
                    break;
                case "*":
                    result = multiply(a,b);
                    break;
            }

            return result;
        }
    }
}
