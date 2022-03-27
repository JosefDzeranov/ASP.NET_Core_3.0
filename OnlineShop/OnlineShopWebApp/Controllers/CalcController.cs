﻿using Microsoft.AspNetCore.Mvc;
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
            if (c != "+" && c != "-" && c != "*" && c != "/" && c != null)
            {
                return "Неверный оператор.\nДоступные операторы:\n< + > - для сложения\n" +
                       "< - > - для вычитания\n< * > - для умножения\n< / > - для деления\n" +
                       "Пример правильного запроса: ../calculator/index?a=2&b=3/&c=*\n" +
                       "Результат: 2 * 3 = 6";
            }
            if (c == "-")
            {
                return $"{a} - {b} = {a - b}";
            }
            if (c == "*")
            {
                return $"{a} * {b} = {a * b}";
            }
            if(c == "/")
            {
                return $"{a} / {b} = {a / b}";
            }
            if (c == null)
            {
                return $"{a} + {b} = {a + b}";
            }
            return $"{a} + {b} = {a + b}";
        }
    }
}
