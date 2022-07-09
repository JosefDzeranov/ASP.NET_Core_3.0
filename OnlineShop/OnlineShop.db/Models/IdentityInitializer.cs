using Microsoft.AspNetCore.Identity;

namespace OnlineShop.db.Models
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminName = "admin@gmail.com";
            var password = "_Aa123456";

            //var adminUser = userManager.FindByNameAsync(adminName).Result;
            //if (adminUser != null)
            //{
            //    userManager.AddToRoleAsync(adminUser, Constants.AdminRoleName).Wait();
            //}

            if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
            }

            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
            }

            if (userManager.FindByNameAsync(adminName).Result == null)
            {
                var admin = new User { UserName = adminName, AvatarPath = "/images/defaultAvatar.png", Email = adminName };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
                }
            }
        }
    }
}