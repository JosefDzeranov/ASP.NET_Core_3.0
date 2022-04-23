using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewUser(User user)
        {
            if (user.Password == user.PasswordConfirm)
            {
                ModelState.AddModelError("", "Passwords should match.");
            }
            if (!ModelState.IsValid)
            {
                return Content($"{user.Login}- not valid");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Login == "Login")
            {
                ModelState.AddModelError("", "Please enter your personal Login.");
            }

            if (!ModelState.IsValid)
            {
                return Content($"{user.Login}- not valid");
            }

            return RedirectToAction("Products","Home");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            return RedirectToAction("Products", "Home");
        }
    }
}
