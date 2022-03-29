using Microsoft.AspNetCore.Mvc;
using OnlineDesignBureauWebApp.Models;
using System.Diagnostics;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class StartController : Controller
    {
        public string hello() 
        {
            var hour = DateTime.Now.Hour;
            if (hour < 6) return "Доброй ночи";
            else if (hour >= 18) return "Добрый вечер";
            else if (hour >= 6 && hour < 12) return "Доброе утро";
            else if (hour >= 12 && hour < 18) return "Добрый день";
            return Convert.ToString(hour);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
