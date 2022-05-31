using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IUserBase _userBase;

        public RegistrationController(IUserBase userBase)
        {
            _userBase = userBase;
        }
        public IActionResult Index()
        {
            return View();
        }

        private void AddNewUser(Registration registration)
        {
            var newUser = new UserViewModel(registration);
            _userBase.Add(newUser.ToUser());
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckName(string login)
        {
            var allUsers = _userBase.AllUsers();
            if (allUsers.Any(x=>x.Login == login)) return Json(false);
            return Json(true);
        }

        [HttpPost]
        public IActionResult Registrate(Registration registration)
        {
            if (ModelState.IsValid)
            {
                AddNewUser(registration);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
