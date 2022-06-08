using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Users()
        {
            var users = userManager.Users.ToList();
            return View(users.ToUsersViewModels());
        }

        public IActionResult Details(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return View(user.ToUserViewModel());
        }

        public IActionResult ChangePassword(string userName)
        {
            var newPassword = new NewPassword()
            {
                UserName = userName
            };
            return View(newPassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(NewPassword newPassword)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(newPassword.UserName).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, newPassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Users");
            }
            return RedirectToAction("ChangePassword");
        }

        public IActionResult Delete(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Users");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = registrationData.Name,
                    Age = registrationData.Age,
                    Email = registrationData.Email,
                    UserName = registrationData.Email
                };
                userManager.CreateAsync(user, registrationData.Password).Wait();
                return RedirectToAction("Users");
            }
            return View(registrationData);
        }

        public IActionResult Edit(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return View(user.ToUserViewModel());
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel userAccount)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(userAccount.Email).Result;
                user.Email = userAccount.Email;
                user.Age = userAccount.Age;
                user.UserName = userAccount.Email;
                user.Name = userAccount.Name;

                userManager.UpdateAsync(user).Wait();
                
                return RedirectToAction("Users");
            }
            else
            {
                return View(userAccount);
            }
        }
    }
}

