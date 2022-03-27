using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {

        public string Hello()
        {
            int hourRightNow = DateTime.Now.Hour;
            if (0 <= hourRightNow && hourRightNow < 6) return "Доброй ночи";
            if (6 <= hourRightNow && hourRightNow < 12) return "Доброе утро";
            if (12 <= hourRightNow && hourRightNow < 18) return "Добрый день";
            if (18 <= hourRightNow && hourRightNow < 24) return "Добрый вечер";
            else return "";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
