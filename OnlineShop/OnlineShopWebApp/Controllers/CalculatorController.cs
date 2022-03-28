using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        

        public string Index(string a, string b)
        {
           
            if (a == null)
            {
                a = "0";
            }
            if (b == null)
            {
                b = "0";
            }

             if (a.Contains('.') || b.Contains('.'))
            {
               a = a.Replace('.', ',');
               b = b.Replace('.', ',');
            }

            return $"{a} + {b} = {Convert.ToDouble(a) + Double.Parse(b)}";
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
