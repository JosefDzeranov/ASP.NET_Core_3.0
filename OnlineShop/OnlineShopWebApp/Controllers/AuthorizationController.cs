using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        
        private readonly ICartServicies _cartBase;
        private readonly SignInManager<User> _signInManager;


        public AuthorizationController(SignInManager<User> signInManager, ICartServicies cartBase)
        {
            _signInManager = signInManager;
            _cartBase = cartBase;
        }


        [HttpGet]
        public IActionResult Authorize(string returnUrl = null)
        {
            return View(new Authorization() { ReturnUrl = returnUrl });

        }

        [HttpPost]
        public IActionResult Authorize(Authorization authorization)
        {

            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(authorization.Name, authorization.Password, authorization.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    if (authorization.ReturnUrl != null)
                    {
                        return Redirect(authorization.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Неправильный логин или пароль");
                }
            }
            return View("Authorize", authorization);
        }

        [Authorize]
        public IActionResult Logout()
        {
            var cart = _cartBase.TryGetByUserName(User.Identity.Name);
            if (cart != null)
            {
                _cartBase.Delete(cart.UserId);
            }
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
