using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;


namespace OnlineShop.DB
{
    public class IdentityInitializer
    {

        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@mail.ru";
            var adminPassword = "Admin1234+";
            if (roleManager.FindByNameAsync(Const.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }
            if (roleManager.FindByNameAsync(Const.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.UserRoleName)).Wait();
            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Login = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, adminPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Const.AdminRoleName).Wait();
                }
            }
        }
    }
}