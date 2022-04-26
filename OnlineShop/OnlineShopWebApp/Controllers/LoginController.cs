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
            return View();
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
                return Content($"{registrationData.Name} {registrationData.Age}");
            }

            return View();
        }
    }
}
