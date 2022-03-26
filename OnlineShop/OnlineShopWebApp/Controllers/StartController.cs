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
            string [] hoursAndMinutes = DateTime.Now.ToShortTimeString().Split(':');
            double hours = double.Parse(hoursAndMinutes[0]);
            double minutes = double.Parse(hoursAndMinutes[1]);
            double time = hours + minutes / 100;

            if(time > 0 && time <= 6)
            {
                return "Доброй ночи";
            }
            if (time > 6 && time <= 12)
            {
                return "Доброе утро";
            }
            if (time > 12 && time <= 18)
            {
                return "Добрый день";
            }
            return "Добрый вечер";
        }
    }
}
