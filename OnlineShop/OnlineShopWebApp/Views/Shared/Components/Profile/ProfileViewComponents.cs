using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Models;

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
            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.FindByNameAsync(User.Identity.Name).Result;
                var avatar = user.AvatarPath;
                return View("Profile", avatar);
            }
            return View("Profile", "/images/defaultAvatar.png");
        }
    }
}