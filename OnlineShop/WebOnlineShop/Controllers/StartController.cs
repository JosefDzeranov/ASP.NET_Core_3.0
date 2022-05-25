using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebOnlineShop.Models;

namespace WebOnlineShop.Controllers
{
    public class StartController : Controller
    {
        public string Hello(DateTime dateTime)
        {
            int timehour = DateTime.Now.Hour;

            if (timehour >= 0 && timehour <= 6)
            {
                return "Доброй ночи";
            }
            if(timehour >= 6 && timehour <= 12)
            {
                return "Доброе утро";
            }
            if(timehour >= 12 && timehour <= 18)
            {
                return "Добрый день";
            }
            return "Добый вечер";
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
