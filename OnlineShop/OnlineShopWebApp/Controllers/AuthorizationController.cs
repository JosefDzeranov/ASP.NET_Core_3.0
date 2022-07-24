using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {

       
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new Authorization() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Authorization authorization)
        {
            var result = _signInManager.PasswordSignInAsync(authorization.Login, authorization.Password, authorization.RememberMe, false).Result;
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(authorization.ReturnUrl))
                {
                    return Redirect(authorization.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {

                ModelState.AddModelError("", "Wrong password");
            }
            return View(authorization);

        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }



        //private readonly IUsersManager regAndAuthManager;

        //public AuthorizationController(IUsersManager regAndAuthManager)
        //{
        //    this.regAndAuthManager = regAndAuthManager;
        //}
        //public IActionResult Index()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Enter(Authorization authorization)
        //{
        //    if (ModelState.IsValid && usersManager.Compare(authorization))
        //    {

        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }

        //}

    }

}