using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(int a, int b)
        {
            return Convert.ToString(a+b) ?? "0";
        }
    }
}
