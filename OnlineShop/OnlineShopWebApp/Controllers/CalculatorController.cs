using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(string a, string b)
        {
            var correctA = double.Parse(a.Replace(".", ","));
            var correctB = double.Parse(b.Replace(".", ","));
            return $"{correctA} + {correctB} = {correctA + correctB}";
        }
    }
}
