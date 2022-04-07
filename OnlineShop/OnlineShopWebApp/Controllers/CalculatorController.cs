using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double a, double b, string c)
        {
            switch (c)
            {
                case "-": return $"{a} - {b} = {a-b}"; 
                case "*": return $"{a} * {b} = {a*b}";
                case null:
                case "+": return $"{a} + {b} = {a+b}";
                default: return "Введены неверные данные";
            }
            
            
            
        }
    }
}
