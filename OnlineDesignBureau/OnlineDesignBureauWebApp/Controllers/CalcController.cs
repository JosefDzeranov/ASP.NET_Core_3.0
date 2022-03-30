using Microsoft.AspNetCore.Mvc;
using OnlineDesignBureauWebApp.Models;
using System.Diagnostics;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CalcController : Controller
    {
        // molostov_lesson2_1_4
        public string Index(string a="0", string b="0", string c="+")
        {
            double temp = 0;
            string result = null;
            if (!(
                double.TryParse(a, out double a1) && double.TryParse(b, out double b1)
                ))
            {
                result = "Один или два передаваемых аргумента не являются числами";
            }
            else
            {
                if (c == null) c = "+";

                switch (c)
                {
                    case "+":
                        temp = a1 + b1;
                        break;
                    case "-":
                        temp = a1 - b1;
                        break;
                    case "*":
                        temp = a1 * b1;
                        break;
                    case "/":
                        if (b1 == 0) result = "На 0 делить нельзя";
                        else temp = a1 / b1;
                        break;
                    default:
                        result = "Введён отсутствующий в программе математический оператор";
                        break;
                }
            }

            if (result == null) result = Convert.ToString($"{a} {c} {b} = {temp}");
            return (result);

        }

    }
}
