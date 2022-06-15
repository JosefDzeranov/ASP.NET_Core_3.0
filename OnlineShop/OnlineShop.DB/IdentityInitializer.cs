using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;


namespace OnlineShop.DB
{
    public class IdentityInitializer
    {

        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@mail.ru";
            var adminPassword = "FghTsEwQ74@";
            if(roleManager.FindByNameAsync(Const.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.AdminRoleName)).Wait();
            }
            if(roleManager.FindByNameAsync(Const.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.UserRoleName)).Wait();
            }
            if( userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, AvatarPath = "/images/defaultAvatar.png" };
                var result = userManager.CreateAsync(admin, adminPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Const.AdminRoleName).Wait();
                }
            }
        }
    }
}
