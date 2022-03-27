using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index (double a, double b)
        {
           var res = a+ b;
           return Ok(res); 
          
        }
    }
}
