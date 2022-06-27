using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UsersController : Controller
    {
        private readonly IUsersManager _usersManager;
        private readonly IRoleManager _roleManager;

        public UsersController(IUsersManager usersManager, IRoleManager roleManager)
        {
            _usersManager = usersManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = _usersManager.GetAll();
            return View(users);
        }

        public IActionResult Details(string login)
        {
            var user = _usersManager.Find(login);
            return View(user);
        }

        public IActionResult ChangePassword(string login)
        {
            ChangePassword changePassword = new ChangePassword()
            {
                Login = login
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.Login == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            var user = _usersManager.Find(changePassword.Login);
            if (user.Password == changePassword.Password)
            {
                ModelState.AddModelError("", "Вы ввели существующий пароль!");
            }
            if (ModelState.IsValid)
            {
                _usersManager.ChangePassword(changePassword.Login, changePassword.Password);
                return RedirectToAction("Index", "Users");
            }
            return View(changePassword);
        }
        public IActionResult Edit(string login)
        {
            var user = _usersManager.Find(login);
            UserInfo userInfo = new UserInfo()
            {
                Login = user.Login,
                Firstname = user.Firstname,
                Secondname = user.Secondname,
                Surname = user.Surname,
                Age = user.Age,
                Phone = user.Phone,
                Email = user.Email
            };
            return View(userInfo);
        }
        [HttpPost]
        public IActionResult Edit(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _usersManager.ChangeInfo(userInfo);
                return RedirectToAction("Index", "Users");
            }
            return View(userInfo);
        }

        public IActionResult EditRights(string login)
        {
            var user = _usersManager.Find(login);
            ChangeRoleUser roleInfo = new ChangeRoleUser
            {
                Login = user.Login,
                Id = user.RoleId,
                RoleName = user.RoleName,
                OtherRoles = _roleManager.GetAll()
            };
            return View(roleInfo);
        }

        [HttpPost]
        public IActionResult EditRights(ChangeRoleUser roleInfo)
        {
            _usersManager.AssignRole(roleInfo.Login, roleInfo.Id);
            return RedirectToAction("Index", "Users");
        }

        public IActionResult Remove(string login)
        {
            _usersManager.Remove(login);
            return RedirectToAction("Index", "Users");
        }

    }
}
