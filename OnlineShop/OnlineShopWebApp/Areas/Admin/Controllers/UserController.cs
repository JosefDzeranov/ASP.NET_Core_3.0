using Microsoft.AspNetCore.Authorization;
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

            return View();
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
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
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
        public IActionResult ChangeInfo(string id)
        {
            var user = userRepository.TryGetById(id);
            var userInfoViewModel = new UserInfoViewModel
            {
                Name = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
                UserId = user.Id,
                PhoneNumber = user.Phone
            };
            return View(userInfoViewModel);
        }
        [HttpPost]
        public IActionResult ChangeInfo(UserInfoViewModel userInfoViewModel)
        {
           var user = userRepository.TryGetById(userInfoViewModel.UserId);
            user.FirstName = userInfoViewModel.Name;
            user.LastName = userInfoViewModel.LastName;
            user.Phone = userInfoViewModel.PhoneNumber;
            user.Email = userInfoViewModel.Email;
            userRepository.Update(user);
            return RedirectToAction("Index", "User");
        }
    }
}
