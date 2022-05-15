using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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
            var newUser = new User(registration);
            _userBase.Add(newUser);
        }


        [HttpPost]
        public IActionResult Registrate(Registration registration)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
