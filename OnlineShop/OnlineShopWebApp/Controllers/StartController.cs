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
            Dawn = 0,
            Morning = 6,
            Noon = 12,
            Evening = 18,
            Night = 24
        }

        public string Hello()
        {
            var currentDateTime = DateTime.Now;
            var hour = Convert.ToInt32(currentDateTime.ToString("H:mm").Substring(0, 2));

            if (hour >= (int)DayParts.Dawn && hour <= (int)DayParts.Morning)
            {
                return "Доброе утро";
            }
            if (hour > (int)DayParts.Morning && hour <= (int)DayParts.Noon)
            {
                return "Добрый день";
            }
            if (hour > (int)DayParts.Noon && hour <= (int)DayParts.Evening)
            {
                return "Добрый вечер";
            }
            if (hour > (int)DayParts.Evening && hour <= (int)DayParts.Night)
            {
                return "Доброй ночи";
            }

            return hour.ToString() ?? "Ну удалось определить время.";
        }
       
    }
}
