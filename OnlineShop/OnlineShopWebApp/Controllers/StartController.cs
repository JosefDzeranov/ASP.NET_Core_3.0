using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            var realTime = DateTime.Now.Hour;
            if (realTime>=0 && realTime<6)
            {
                return "Доброй ночи";
            }
            else if (realTime >= 6 && realTime < 12)
            {
                return "Доброе утро";
            }
            else if (realTime >= 12 && realTime < 18)
            {
                return "Добрый день";
            }
            else 
            {
                return "Добрый вечер";
            }
        }
    }
}
