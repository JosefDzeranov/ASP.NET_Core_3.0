using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Helpers;
using OnlineShop.db.Models;
using System.Linq;
using System.Collections.Generic;
using OnlineShop.db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Areas.Admin.Views.User;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> rolesManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> rolesManager)
        {
            this.userManager = userManager;
            this.rolesManager = rolesManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users.Select(u => u.ToUserViewModel()).ToList());
        }
        public IActionResult Detail(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }
        public IActionResult ChangePassword(string id)
        {
            var changePassword = new ChangePassword()
            {
                UserName = id
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)

            {
                var user = userManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Remove(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult Edit(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userAccount)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(userAccount.FirstName).Result;

                user.UserName = userAccount.FirstName;
                user.PhoneNumber = userAccount.Phone;
                user.Email = userAccount.Email;

                userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Index");
            }
            else
            {
                return View(userAccount);
            }
        }
        public IActionResult EditRights(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();

            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(string userName, Dictionary<string, string> UserRolesViewModel)
        {
            var userSelectedRoles = UserRolesViewModel.Select(x => x.Key);

            var user = userManager.FindByNameAsync(userName).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;

            userManager.RemoveFromRolesAsync(user, userRoles).Wait();
            userManager.AddToRolesAsync(user, userSelectedRoles).Wait();

            return Redirect($"/Admin/User/Detail?name={userName}");
        }

    }
}
