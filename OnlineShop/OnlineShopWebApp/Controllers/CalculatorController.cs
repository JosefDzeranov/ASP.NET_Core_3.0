using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(string a, string b)
        {
            var convertA = Converter(a);
            var convertB = Converter(b);
            return $"{convertA} + {convertB} = {convertA + convertB}";
        }

        public static double Converter(string a)
        {
            
            a = a.Replace(".", ",");

            return double.Parse(a);
        }
    }
}
