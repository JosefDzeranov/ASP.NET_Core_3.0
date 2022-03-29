using Microsoft.AspNetCore.Mvc;
using OnlineDesignBureauWebApp.Models;
using System.Diagnostics;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // Задача lession2_1_3
        public string Index(double a, double b, string operators = "+")
        {
            double temp=0;
            switch (operators)
            {
                case "+":
                    temp = a + b;
                    break;
                case "-":
                    temp = a - b;
                    break;
                case "*":
                    temp = a * b;
                    break;
            }            
            string c;
            if (temp % 1 == 0)
            {
                c = Convert.ToString((int)temp);
            }
            else
            {
                c = Convert.ToString(temp);
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
