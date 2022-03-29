using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(int  a, int b, char c)
        {
            return Convert.ToString(Action(a, b, c))??"Вы неправильно передали операцию. Обратитесь в службу поддержки.";
        }

        Func<int, int, int> summ = (a, b) => { return a + b; };
        Func<int, int, int> differece = (a, b) => { return a - b; };
        Func<int, int, int> multiply = (a, b) => { return a * b; };

        public int Action(int a, int b, char c)
        {
            var result = 0;

            switch (c)
            {
                case '+':
                    result = summ(a,b);
                    break;
                case '-':
                    result = differece(a,b);
                    break;
                case '*':
                    result = multiply(a,b);
                    break;
            }

            return result;
        }
    }
}
