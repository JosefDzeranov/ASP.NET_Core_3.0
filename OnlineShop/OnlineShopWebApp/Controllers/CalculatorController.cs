using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public double Index(double a, double b)
        {
            return a + b;
        }
    }
}
