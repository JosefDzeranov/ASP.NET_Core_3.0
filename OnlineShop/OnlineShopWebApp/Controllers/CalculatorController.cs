using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index(double a, double b, char c)
        {
            return c switch
            {
                '+' => Ok($"{a} + {b} = {a + b}"),
                '-' => Ok($"{a} - {b} = {a - b}"),
                '*' => Ok($"{a} * {b} = {a * b}"),
                //'/' => Ok($"{a} / {b} = {a / b}"),
                _ => Ok($"{a} + {b} = {a + b}"),
            };
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
