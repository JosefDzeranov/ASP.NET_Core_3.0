using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(string a, string b, string c)
        {
            var convertA = Converter(a);
            var convertB = Converter(b);
            if (c!= null)
            {
                
                switch (c)
                {
                    case "+":
                        return $"{convertA} {c} {convertB} = {convertA + convertB}";

                    case "-":
                        return $"{convertA} {c} {convertB} = {convertA - convertB}";
                    case "*":
                        return $"{convertA} {c} {convertB} = {Math.Round((convertA * convertB), 2)}";
                    default:
                        //защита от "дурака"
                        return "Неверный оператор! \n" +
                       "допускаются следующие значения:\n" +
                       "сложение: +\n" +
                       "вычитание: -\n" +
                       "умножение: *";
                }
            }
            return $"{convertA} + {convertB} = {convertA + convertB}";
            
        }
        public static double Converter(string a)
        {

            a = a.Replace(".", ",");

            return double.Parse(a);
        }

    }
}
