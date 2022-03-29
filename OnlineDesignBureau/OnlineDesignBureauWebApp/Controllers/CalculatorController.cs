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
            return Convert.ToString(a + b);
        }

    }
}
