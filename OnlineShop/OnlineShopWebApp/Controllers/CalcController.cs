using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        public string Index(string a = "0", string b = "0", char c = '+')
        {
            double dA = Converter(a);
            double dB = Converter(b);
            string result = string.Empty;
            if (dB == 0 && c == '/')
                return result = "Делить на 0 нельзя";
            else
            {
                switch (c)
                {
                    case '+': return result = $"{dA} + {dB} = {dA + dB}";
                    case '-': return result = $"{dA} - {dB} = {dA - dB}";
                    case '*': return result = $"{dA} * {dB} = {dA * dB}";
                    case '/': return result = $"{dA} / {dB} = {dA / dB}";
                }

            }
            return result;
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
