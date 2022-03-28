using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
            
        }

        public string Index(string a = "0", string b = "0")
        {
            double dA = Converter(a);
            double dB = Converter(b);
            return $"{a} + {b} = {dA + dB}";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public double Converter(string value)
        {
            value = value.Replace(".", ",");
            return double.Parse(value);
        }
    }
}
