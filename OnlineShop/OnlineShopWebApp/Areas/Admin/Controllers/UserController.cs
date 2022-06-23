using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Interface;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUserStorage userStorage;

        public UserController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public IActionResult Index()
        {
            var users = userStorage.GetAll();

            return View(users);
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
                userStorage.Add(signup);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetInfoUser(Guid id)
        {
            var user = userStorage.TryGetUserById(id);

            return View(user);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var user = userStorage.TryGetUserById(id);

            var data = new ChangePassword()
            {
                Id = user.Id,
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
                userStorage.ChangePassword(data);

                return View("Success");
            }

            return View(data);
        }

        public IActionResult Edit(Guid id)
        {
            var user = userStorage.TryGetUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userStorage.Edit(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            userStorage.Remove(id);
            return RedirectToAction("Index"); ;
        }
    }
}