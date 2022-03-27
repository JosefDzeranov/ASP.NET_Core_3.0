using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            int HourNow = DateTime.Now.Hour;

            if(HourNow > 0 && HourNow < 6)
            {
                return "Доброй ночи";
            }
            else if(HourNow > 6 && HourNow < 12)
            {
                return "Доброе утро";
            }
            else if(HourNow > 12 &&  HourNow < 18)
            {
                return "Добрый день";
            }
            else return "Добрый вечер"; 

        }
    }
}
