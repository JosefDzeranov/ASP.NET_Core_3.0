﻿using Microsoft.AspNetCore.Mvc;
using WebOnlineShop.Models;
using System.Diagnostics;

namespace WebOnlineShop.Controllers
{
    public class Calc : Controller
    {
        public string Index(double a, double b, string c)
        {
            if(a / b == 0 || b / a == 0)
            {
                return $"На 0 делить нельзя";
            }
            else
            {
                if (c == "+")
                {
                    return $"{a}+{b} = {a + b}";
                }
                else if (c == "-")
                {
                    return $"{a}-{b} = {a - b}";
                }
                else if (c == "*")
                {
                    return $"{a}/{b} = {a / b}";
                }

                return $"{a}/{b} = {a / b}";
            }
            
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
