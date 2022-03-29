using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index(double a, double b, string c)
        {
            if ((string.IsNullOrEmpty(c) || c == "" || c == "+" || c == "-" || c == "*") || (b != 0 && c !="/"))
            {
                switch (c)
                {
                    case "+":
                        return Ok($"{a} + {b} = {a + b}");
                    case "-":
                        return Ok($"{a} - {b} = {a - b}");
                    case "*":
                        return Ok($"{a} * {b} = {a * b}");
                    case "/":
                        return Ok($"{a} + {b} = {a / b}");
                    default:
                        return Ok($"{a} + {b} = {a + b}");
                }
            }
            else if (b != 0 && c != "/")
                return Content("\r\n На ноль делить нельзя");
            else 
                return Content("\r\n Пример запроса https://localhost:5001/calculator/index/1/3/+ \r\n Приниматься могут только операции +, -, *.");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
