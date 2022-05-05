using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = userRepository.GetAll();

            return View(users);
        }

        public IActionResult UserDetails(Guid id)
        {
            var user = userRepository.TryGetById(id);

            return View(user);
        }
        public IActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(RegisterViewModel registerVM)
        {
            if (registerVM.Password == registerVM.Name)
            {
                ModelState.AddModelError("Name", "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Password = registerVM.Password,

                };
                if (userRepository.Add(user))
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
                }


            }
            return View();
        }
        
        public IActionResult DeleteUser(Guid id)
        {
            userRepository.Delete(id);

            return RedirectToAction("Index", "User");
        }
        public IActionResult ChangePassword(Guid id)
        {
            var user = userRepository.TryGetById(id);
            var userPasswordViewModel = new UserPasswordViewModel
            {
                Password = user.Password,
                ConfirmPassword = user.Password,
                UserId = user.Id,
            };
            return View(userPasswordViewModel);
        }
        [HttpPost]
        public IActionResult ChangePassword(UserPasswordViewModel userPasswordViewModel)
        {
            var user = userRepository.TryGetById(userPasswordViewModel.UserId);
            user.Password = userPasswordViewModel.Password;
            userRepository.Update(user);
            return RedirectToAction("Index", "User");
        }
    }
}
