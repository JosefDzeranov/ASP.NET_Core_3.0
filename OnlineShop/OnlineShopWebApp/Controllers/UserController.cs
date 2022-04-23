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

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError("", "Name and Login should not be the same.");
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
