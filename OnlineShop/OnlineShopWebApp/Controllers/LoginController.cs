using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(string login, string password, bool remember)
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Registrate(string login, string password1, string password2)
        {
            return View();
        }
    }
}
