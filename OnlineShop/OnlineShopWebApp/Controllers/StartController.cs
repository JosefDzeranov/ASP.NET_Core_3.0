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
            var date1 = DateTime.Now.TimeOfDay;
            if (date1 > new TimeSpan(0, 0, 0) & date1 < new TimeSpan(6, 0, 0))
            {
                return "Доброй ночи";
            }
            if (date1 > new TimeSpan(6, 0, 0) & date1 < new TimeSpan(12, 0, 0))
            {
                return "Доброй утро";
            }
            if (date1 > new TimeSpan(12, 0, 0) & date1 < new TimeSpan(18, 0, 0))
            {
                return "Добрый день";
            }
            if (date1 > new TimeSpan(18, 0, 0) & date1 < new TimeSpan(24, 0, 0))
            {
                return "Добрый вечер";
            }
            return "";
        }
    }
}
