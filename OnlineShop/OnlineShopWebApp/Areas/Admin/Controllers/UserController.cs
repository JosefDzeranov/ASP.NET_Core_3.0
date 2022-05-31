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
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(IUserRepository userRepository, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            var usersViewModel = users.MappingToListUserViewModel();

            return View(usersViewModel);
        }

        public IActionResult UserDetails(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var userViewModel = user.MappingToUserViewModel();

            return View(userViewModel);
        }
        public IActionResult AddUser()
        {
            var roles = roleManager.Roles.ToList();

            return View(new RegisterViewModel() {Roles = roles});
        }

        [HttpPost]
        public IActionResult AddUser(RegisterViewModel registerViewModel)
        {
            if (registerViewModel.Password == registerViewModel.FirstName)
            {
                ModelState.AddModelError("Name", "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = registerViewModel.MappingToUserFromRegisterViewModel();
               
                   var result = userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, registerViewModel.Role).Wait();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        
        public IActionResult Delete(string id)
        {
            userRepository.Delete(id);

            return RedirectToAction("Index", "User");
        }
        public IActionResult ChangePassword(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var userPasswordViewModel = new UserPasswordViewModel();
            userPasswordViewModel.Id = user.Id;
            
            return View(userPasswordViewModel);
        }
        [HttpPost]
        public IActionResult ChangePassword(UserPasswordViewModel userPasswordViewModel)
        {
            var user = userManager.FindByIdAsync(userPasswordViewModel.Id).Result;
            var result =  userManager.ChangePasswordAsync(user, userPasswordViewModel.OldPassword, userPasswordViewModel.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(userPasswordViewModel);
        }
        public IActionResult ChangeInfo(string id)
        {
            var result = userManager.FindByIdAsync(id).Result;
            var userInfoViewModel = result.MappingToUserInfoViewModel();
            userInfoViewModel.Roles =  roleManager.Roles.ToList();

            return View(userInfoViewModel);
        }
        [HttpPost]
        public IActionResult ChangeInfo(UserInfoViewModel userInfoViewModel)
        {
            var result = userManager.FindByIdAsync(userInfoViewModel.Id).Result;
            var user = userInfoViewModel.MappingToUserFromUserInfoViewModel(result);
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Index", "User");
        }
    }
}
