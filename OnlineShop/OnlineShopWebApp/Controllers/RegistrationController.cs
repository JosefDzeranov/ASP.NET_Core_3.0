using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        //private readonly IUsersManager regAndAuthManager;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        //public RegistrationController(IUsersManager regAndAuthManager)
        //{
        //    this.regAndAuthManager = regAndAuthManager;
        //}

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public  IActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = registration.Login, Email = registration.Login };

                var result = userManager.CreateAsync(user, registration.Password).Result;

                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, true).Wait();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "The user with this email is already registered.");
                }



                //regAndAuthManager.RegisterUser(registration);

            }
           
            
             //   return View();
               return RedirectToAction("Index");
            

        }

    }

}