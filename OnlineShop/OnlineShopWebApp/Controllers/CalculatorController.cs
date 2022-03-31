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
            double correctA, correctB;
            if (a != null)
                correctA = double.Parse(a.Replace(".", ","));
            else
                correctA = 0;

            if (b != null)
                correctB = double.Parse(b.Replace(".", ","));
            else
                correctB = 0;

            return $"{correctA} + {correctB} = {correctA + correctB}";
        }
    }
}
