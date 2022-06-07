using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
