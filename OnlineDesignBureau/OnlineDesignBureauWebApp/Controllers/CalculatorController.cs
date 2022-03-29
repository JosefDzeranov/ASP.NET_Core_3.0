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
            return Convert.ToString(temp);
        }
    }
}
