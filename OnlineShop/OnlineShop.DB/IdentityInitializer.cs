using Domains;
using Microsoft.AspNetCore.Identity;


namespace OnlineShop.DB
{
    public class IdentityInitializer
    {

        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var userEmail = "user@mail.ru";
            var userPassword = "User1234+";
            var adminEmail = "admin@mail.ru";
            var adminPassword = "Admin1234+";
            if (roleManager.FindByNameAsync(Const.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Const.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Const.UserRoleName)).Wait();
            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Login = adminEmail, UserName = adminEmail };
                var resultForAdmin = userManager.CreateAsync(admin, adminPassword).Result;
                if (resultForAdmin.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Const.AdminRoleName).Wait();
                }
            }
            if(userManager.FindByNameAsync(userEmail).Result == null)
            {
                var user = new User { Login = userEmail, UserName = userEmail };
                var resultForUser = userManager.CreateAsync(user, userPassword).Result;
                if (resultForUser.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Const.UserRoleName).Wait();
                }
            }
        }
    }
}