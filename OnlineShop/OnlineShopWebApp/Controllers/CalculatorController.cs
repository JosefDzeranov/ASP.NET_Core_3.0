using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double a, double b, string c)
        {
            if(c!= null)
            {
                switch (c)
                {
                    case "+":
                        return $"{a} {c} {b} = {a + b}";

                    case "-":
                        return $"{a} {c} {b} = {a - b}";
                    case "*":
                        return $"{a} {c} {b} = {a * b}";
                    default:
                        return "Неверный оператор! \n" +
                       "допускаются следующие значения:\n" +
                       "сложение: +\n" +
                       "вычитание: -\n" +
                       "умножение: *";
                }
            }
            return $"{a} + {b} = {a + b}";
            
        }
    }
}
