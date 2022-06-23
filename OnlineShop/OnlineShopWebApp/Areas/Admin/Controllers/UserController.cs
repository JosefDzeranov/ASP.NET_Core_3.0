using Microsoft.AspNetCore.Identity;
using System.Linq;
using OnlineShopWebApp.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userRoles = userManager.GetRolesAsync(user).Result;
                var userViewModel = user.ToUserViewModel(userRoles);
                userViewModels.Add(userViewModel);
            }
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
            var userRoles = userManager.GetRolesAsync(user).Result;
            var userViewModel = user.ToUserViewModel(userRoles);
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
                user.UserName = model.Email;
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

        public IActionResult EditRights(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                var userRoles = userManager.GetRolesAsync(user).Result;
                var allRoles = roleManager.Roles.ToList();
                var roleViewModel = new RoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(roleViewModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditRights(string userId, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(userId).Result;
                if (user != null)
                {
                    var userRoles = userManager.GetRolesAsync(user).Result;
                    //var allRoles = roleManager.Roles.ToList();
                    var addedRoles = roles.Except(userRoles);
                    var removedRoles = userRoles.Except(roles);

                    userManager.AddToRolesAsync(user, addedRoles).Wait();
                    userManager.RemoveFromRolesAsync(user, removedRoles).Wait();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}