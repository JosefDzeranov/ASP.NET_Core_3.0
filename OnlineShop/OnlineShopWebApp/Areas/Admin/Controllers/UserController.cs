using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        public UserController(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public IActionResult Index()
        {
            var users = _userStorage.GetAll();
            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SignUp signup)
        {
            if (ModelState.IsValid)
            {
                _userStorage.Add(signup);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(Guid id)
        {
            var user = _userStorage.TryGetById(id);
            return View(user);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var user = _userStorage.TryGetById(id);
            var data = new ChangePassword() { User = user };
            return View(data);
        }
        
        [HttpPost]
        public IActionResult ChangePassword(Guid id, ChangePassword data)
        {
            if(ModelState.IsValid)
            {
                _userStorage.ChangePassword(id, data);
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userStorage.TryGetById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            if (ModelState.IsValid)
            {
                _userStorage.Edit(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            _userStorage.Remove(id);
            return RedirectToAction("Index"); ;
        }
    }
}
