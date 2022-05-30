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
            if(roleManager.FindByNameAsync(Const.AdminRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.AdminRole)).Wait();
            }
            if(roleManager.FindByNameAsync(Const.UserRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.UserRole)).Wait();
            }
            if( userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, adminPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Const.AdminRole).Wait();
                }
            }
        }
    }
}
