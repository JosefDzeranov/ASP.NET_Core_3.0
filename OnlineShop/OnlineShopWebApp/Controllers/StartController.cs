using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        /*
        test on
        https://localhost:5001/start/hello
        */

        public enum DayParts
        {
            Morning = 6,
            Noon = 12,
            Evening = 18,
            Night = 24
        }

        public string Hello()
        {
            var currentHour = DateTime.Now.Hour;

            if (currentHour < (int)DayParts.Morning)
            {
                return "Доброе утро";
            }
            if (currentHour < (int)DayParts.Noon)
            {
                return "Добрый день";
            }
            if (currentHour < (int)DayParts.Evening)
            {
                return "Добрый вечер";
            }
            
            return "Доброй ночи";
        }
    }
}
