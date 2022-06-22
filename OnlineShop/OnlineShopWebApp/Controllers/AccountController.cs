﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserStorage userStorage;
        
        public AccountController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(SignIn signin)
        {
            if (ModelState.IsValid)
            {
                if (userStorage.Authorize(signin))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Failed");
                }
            }
            return View(signin);
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignUp signup)
        {
            if(signup.Email == signup.Password)
            {
                ModelState.AddModelError(string.Empty, "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                userStorage.Add(signup);
                return RedirectToAction("Index", "Home");
            }
            return View(signup);
        }
    }
}