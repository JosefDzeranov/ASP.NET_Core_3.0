using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        public string Index(double a, double b, string c)
        {
            if (c != "+" && c != "*" && c != "-" && c != null)
            {
                return "Введите в конце один из знаков '-','+' или '*'";
            }
            if (c == "+" || c == null)
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
            return "";
        }
    }
}
