using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index (double a, double b)
        {
           
            return Ok($"{a} + {b} = {a + b}"); 
          
        }
    }
}
