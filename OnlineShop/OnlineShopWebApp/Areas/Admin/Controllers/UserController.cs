using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class UserController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var usersViewModel = users.MappingToListUserViewModel();

            return View(usersViewModel);
        }

        public async Task<IActionResult> UserDetailsAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var userViewModel = user.MappingToUserViewModel();

            return View(userViewModel);
        }
        public async Task<IActionResult> AddUserAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();

            return View(new AddUserViewModel() { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserViewModel registerViewModel)
        {
            if (registerViewModel.Password == registerViewModel.FirstName)
            {
                ModelState.AddModelError("Name", "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = registerViewModel.MappingToUserFromRegisterViewModel();

                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, registerViewModel.Role);
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

        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Index", "User");
        }
        public async Task<IActionResult> ChangePasswordAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var userPasswordViewModel = new UserPasswordViewModel();
            userPasswordViewModel.Id = user.Id;

            return View(userPasswordViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(UserPasswordViewModel userPasswordViewModel)
        {
            var user = await userManager.FindByIdAsync(userPasswordViewModel.Id);
            if (user != null)
            {
                var passwordValidator =
               HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                var passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;
                var result = await passwordValidator.ValidateAsync(userManager, user, userPasswordViewModel.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, userPasswordViewModel.NewPassword);
                    await userManager.UpdateAsync(user);
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

            return View(userPasswordViewModel);
        }
        public async Task<IActionResult> ChangeInfoAsync(string id)
        {
            var result = await userManager.FindByIdAsync(id);
            var userInfoViewModel = result.MappingToUserInfoViewModel();
            userInfoViewModel.AllRoles = await roleManager.Roles.ToListAsync();
            userInfoViewModel.UserRoles = (await userManager.GetRolesAsync(result)).ToList();

            return View(userInfoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeInfoAsync(UserInfoViewModel userInfoViewModel)
        {
            var result = await userManager.FindByIdAsync(userInfoViewModel.Id);
            if (result != null)
            {
                var user = userInfoViewModel.MappingToUserFromUserInfoViewModel(result);
                await userManager.UpdateAsync(user);
                var userRoles = (await userManager.GetRolesAsync(user)).ToList();
                var addedRoles = userInfoViewModel.UserRoles.Except(userRoles);
                var removedRoles = userRoles.Except(userInfoViewModel.UserRoles);
                foreach (var role in addedRoles)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                foreach (var role in removedRoles)
                {
                    await userManager.RemoveFromRoleAsync(user, role);
                }

                return RedirectToAction("Index", "User");

            }

            return NotFound();
        }
    }
}
