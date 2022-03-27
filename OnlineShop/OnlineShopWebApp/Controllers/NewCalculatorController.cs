using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class NewCalculatorController : Controller
    {
        public IActionResult Index(double a, double b, char c)
        {
            double res = 0;

            if (c!='-'&& c!='+'&& c!='*'&& c=='0')
            {
                return StatusCode(400, "Введите корректный знак операции");
            }

           else if (c=='-')
            {
                res =  a - b;
               
            }
            else if (c=='*')
            {
                res = a * b;
            }
          
            else 
            {
                c = '+';
                res = a + b;
            }
            return Ok ($"{ a} { c} { b} = { res}");
        }
    }
}
