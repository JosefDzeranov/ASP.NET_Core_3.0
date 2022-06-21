using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;

namespace OnlineShop.Db
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
                var admin = new User { UserName = adminName, AvatarPath = "/images/defaultAvatar.png", Email = adminName, Phone = "123" };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
                }
            }

            
        }
    }
}