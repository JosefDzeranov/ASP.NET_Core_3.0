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

            var aConv = Convert.ToDouble(a);
            var bConv = Convert.ToDouble(b);

            switch (c)
            {
                case "+": return $"{aConv} + {bConv} = {aConv + bConv}";
                case "-": return $"{aConv} - {bConv} = {aConv - bConv}";
                case "*": return $"{aConv} * {bConv} = {aConv * bConv}";
                case "/":
                    if (bConv == 0)
                    {
                        return "Попытка деления на ноль:( ";
                    }
                    else
                    {
                        return $"{aConv} / {bConv} = {aConv / bConv}";
                    }

                default:
                    break;
            }


            if ((c != "+" && c != null) || (c != "-" && c != null) || (c != "*" && c != null))
            {
                return "Используйте операторы +, -, *";
            }

            return $"{aConv} + {bConv} = {aConv + bConv}";

        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
