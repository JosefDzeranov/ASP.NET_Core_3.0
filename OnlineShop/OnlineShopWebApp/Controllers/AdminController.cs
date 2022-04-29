using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        // ertegerg
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Status()
        {
            return View();
        }
    }
}
