using Microsoft.AspNetCore.Mvc;
using OnlineDesignBureauWebApp.Models;
using System.Diagnostics;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // Задача lession2_1_2
        public string index (double a, double b) 
        {
            string c;
            if (a%1 == 0 && b % 1 == 0)
            {
                c = Convert.ToString((int)a + (int)b);
            }
            else
            {
                c = Convert.ToString(a + b);
            }
            return c;

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
