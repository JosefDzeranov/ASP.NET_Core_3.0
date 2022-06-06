using Microsoft.AspNetCore.Mvc;
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
        private readonly IUsersRepository usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Users()
        {
            var users = usersRepository.GetAll();
            return View(users);
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
                    Login = registrationData.Login,
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

