using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            var userViewModels = users.ToUserViewModels();
            return View(userViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ToUser();
                userManager.CreateAsync(user, model.Password).Wait();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetInfoUser(Guid id)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            var data = new ChangePasswordViewModel()
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(model.Id.ToString()).Result;
                userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword).Wait();
            }

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(model.Id.ToString()).Result;

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;

                userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Remove(Guid id)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Index");
        }
    }
}