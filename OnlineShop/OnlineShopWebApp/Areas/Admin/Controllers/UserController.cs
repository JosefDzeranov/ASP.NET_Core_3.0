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
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
        public IActionResult Add(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ToUser();
                _userManager.CreateAsync(user, model.Password).Wait();
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
                var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;
                _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword).Wait();
                return View("Success");
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Email;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;

                _userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Remove(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            _userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Index");
        }


        public IActionResult EditRights(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            if (user != null)
            {
                var userRoles = _userManager.GetRolesAsync(user).Result;
                var allRoles = _roleManager.Roles.ToList();
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
                var user = _userManager.FindByIdAsync(userId).Result;
                if (user != null)
                {
                    var userRoles = _userManager.GetRolesAsync(user).Result;
                    var allRoles = _roleManager.Roles.ToList();
                    var addedRoles = roles.Except(userRoles);
                    var removedRoles = userRoles.Except(roles);

                    _userManager.AddToRolesAsync(user, addedRoles).Wait();
                    _userManager.RemoveFromRolesAsync(user, removedRoles).Wait();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



    }
}
