﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;


        public UserController(IUserRepository userRepository, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            //var users = userRepository.GetAll();
            var users = userManager.Users.ToList();

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
                var user = new UserViewModel
                {
                    FirstName = registerVM.Name,
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
        
        public IActionResult Delete(Guid id)
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
        public IActionResult ChangeInfo(Guid id)
        {
            var user = userRepository.TryGetById(id);
            var userInfoViewModel = new UserInfoViewModel
            {
                Name = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
                UserId = user.Id,
                Phone = user.Phone
            };
            return View(userInfoViewModel);
        }
        [HttpPost]
        public IActionResult ChangeInfo(UserInfoViewModel userInfoViewModel)
        {
           var user = userRepository.TryGetById(userInfoViewModel.UserId);
            user.FirstName = userInfoViewModel.Name;
            user.LastName = userInfoViewModel.LastName;
            user.Phone = userInfoViewModel.Phone;
            user.Email = userInfoViewModel.Email;
            userRepository.Update(user);
            return RedirectToAction("Index", "User");
        }
    }
}
