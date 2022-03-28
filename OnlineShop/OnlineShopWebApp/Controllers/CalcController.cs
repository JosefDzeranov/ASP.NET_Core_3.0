using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        public string Index(string a, string b, string c)
        {
            double d, e;
            if (a != null)
            {
                d = double.Parse(a.Replace(".", ","));
            }
            else
            {
                d = 0;
            }

            if (b != null)
            {
                e = double.Parse(b.Replace(".", ","));
            }
            else
            {
                e = 0;
            }

            if (c != "+" && c != "-" && c != "*" && c != "/" && c != null)
            {
                return "Неверный оператор.\nДоступные операторы:\n< + > - для сложения\n" +
                       "< - > - для вычитания\n< * > - для умножения\n" +
                       "Пример правильного запроса: ../calc/index?a=2&b=3&c=*" +
                       "Результат: 2 * 3 = 6";
            }

            switch (c)
            {
                case "-":
                    return $"{d} - {e} = {d - e}";
                case "*":
                    return $"{d} * {e} = {Math.Round(d * e, 2)}";
                case "/":
                    if (e == 0)
                    {
                        return "На ноль делить нельзя.";
                    }
                    else
                    {
                        return $"{d} / {e} = {Math.Round(d / e, 2)}";
                    }
                default:
                    return $"{d} + {e} = {d + e}";
            }
        }
    }
}
