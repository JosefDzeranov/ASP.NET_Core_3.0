using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Profile
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public ProfileViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user.ToUserViewModel());
        }
    }
}
