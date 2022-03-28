using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Hello()
        {
            var date = DateTime.Now;
            var res = string.Empty;

            if (date.Hour < 6)
                res = "Доброй ночи";
            else if (date.Hour < 12)
                res = "Доброе утро";
            else if (date.Hour < 18)
                res = "Добрый день";
            else
                res = "Добрый вечер";

            return Ok(res);
        }
    }
}
