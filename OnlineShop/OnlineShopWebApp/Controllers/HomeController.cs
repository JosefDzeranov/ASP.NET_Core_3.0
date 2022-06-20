using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductDataSource productDataSource;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly UserManager<User> userManager;
        public HomeController(IProductDataSource productDataSource, RoleManager<IdentityRole> rolesManager, UserManager<User> userManager)
        {
            this.productDataSource = productDataSource;
            this.rolesManager = rolesManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var t = User.IsInRole(Constants.AdminRoleName);
            //var r =userManager.GetRolesAsync(userManager.FindByNameAsync(User.Identity.Name).Result).Result;
            var products = productDataSource.GetAllProducts();
            return View(Mapping.ToProductViewModels(products));
        }
    }
}
