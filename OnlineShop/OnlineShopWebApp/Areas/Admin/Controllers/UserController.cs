using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Users()
        {
            var users = userManager.Users.ToList();
            return View(users.Select(x => x.Name));
        }

        public IActionResult Details(string userLogin)
        {
            var user = usersRepository.TryGetByLogin(userLogin);
            return View(user);
        }

        public IActionResult ChangePassword(string userLogin)
        {
            var newPassword = new NewPassword()
            {
                Login = userLogin
            };
            return View(newPassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(NewPassword newPassword)
        {
            usersRepository.ChangePassword(newPassword);
            return RedirectToAction("Users");
        }

        public IActionResult Delete(string userLogin)
        {
            usersRepository.Delete(userLogin);
            return RedirectToAction("Users");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                usersRepository.Add(new UserViewModel
                {                   
                    Password = registrationData.Password,
                    Name = registrationData.Name,
                    Age = registrationData.Age,
                    Email = registrationData.Email
                });
                return RedirectToAction(nameof(UserController.Users), "UserViewModel");
            }
            else
            {
                return View(registrationData);
            }
        }
        public IActionResult Edit(string userLogin)
        {
            var user = usersRepository.TryGetByLogin(userLogin);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel userAccount, string userLogin)
        {
            if (ModelState.IsValid)
            {
                usersRepository.Edit(userAccount, userLogin);
                return RedirectToAction("Products");
            }
            else
            {
                return View(userAccount);
            }
        }
    } }

