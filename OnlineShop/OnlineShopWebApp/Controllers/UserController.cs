using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager buyerManager)
        {
            this.userManager = buyerManager;
        }
        public IActionResult Index(string userLigin)
        {
            var user = userManager.FindByLogin(userLigin);
            return View(user);
        }
    }
}
