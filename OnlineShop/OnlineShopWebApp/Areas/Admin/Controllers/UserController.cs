using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccounts = usersManager.GetAll();
            return View(userAccounts);
        }

        public IActionResult Detail(string name)
        {
            var userAccount = usersManager.TryGetByName(name);
            return View(userAccount);
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
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult Remove(string id)
        {
            usersManager.Remove(id);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = usersManager.TryGetByName(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                usersManager.Edit(user);
                return RedirectToAction(nameof(Index));
            }
            return View(usersManager);
        }
    }
}
