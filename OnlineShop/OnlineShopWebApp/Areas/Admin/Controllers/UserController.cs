using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = users.ToUserViewModels();
            return View(userViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SignupViewModel signup)
        {
            if (ModelState.IsValid)
            {
                var user = signup.ToUser();
                _userManager.CreateAsync(user, signup.Password).Wait();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var data = new ChangePassword()
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword data)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(data.Id.ToString()).Result;
                _userManager.ChangePasswordAsync(user, data.CurrentPassword, data.NewPassword).Wait();
                return View("Success");
            }
            return View(data);
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(userViewModel.Id.ToString()).Result;

                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.UserName = userViewModel.Email;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.Phone;

                _userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        public IActionResult Remove(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            _userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Index");
        }
    }
}
