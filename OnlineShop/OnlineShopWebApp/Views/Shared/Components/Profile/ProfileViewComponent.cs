using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Profile
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public ProfileViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
             {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var avatar = user.AvatarPath;
                return View("Profile", avatar);
            }

            return View("Profile", "/images/defaultAvatar.png");

        }
    }
}
