using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
       

        public string Index(string a, string b, string c)
        {
            if (c == "+" )
            {
                return $"{a} + {b} = {a + b}";
            }

            if (c == "-")
            {
                return $"{a} - {b} = {a - b}";
            }

            if (c == "*")
            {
                return $"{a} * {b} = {a * b}";
            }
        

            if ((c != "+" && c != null) || (c != "-" && c != null) || (c != "*" && c != null))
            {
                return "Используйте операторы +, -, *";
            }

            return $"{a} + {b} = {a + b}";

        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
