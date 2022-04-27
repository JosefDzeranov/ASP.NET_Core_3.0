using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
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
        public IActionResult Enter(EnterData enterData)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View(enterData);
            }
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrate(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View(registrationData);
            }
        }
    }
}
