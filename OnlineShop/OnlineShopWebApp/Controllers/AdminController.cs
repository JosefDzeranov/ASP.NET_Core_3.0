using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Status()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }
}
