using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {


        public string Hello()
        {
            DateTime date = DateTime.Now;

            if (date.Hour >= 0 && date.Hour < 6)
            {
                return "Доброй ночи!";
            }
            else if (date.Hour >= 6 && date.Hour < 12)
            {
                return "Доброе утро!";
            }
            else if (date.Hour >= 12 && date.Hour < 18)
            {
                return "Добрый день!";
            }
            
            return  "Добрый вечер!";
        }

         

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
