using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrderController : Controller
    {
        private readonly IBuyerManager buyerManager;
        private readonly IUserManager userManager;
        public OrderController(IBuyerManager buyerManager, IUserManager userManager)
        {
            this.buyerManager = buyerManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            return View(buyerManager.FindBuyer(buyerLogin));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying()
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            buyerManager.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new {buyerId = buyerLogin });
        }

        [HttpPost]
        public IActionResult BuyValid(InfoBuying infoBuying)
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            if (ModelState.IsValid)
            {
                buyerManager.SaveInfoBuying(infoBuying, buyerLogin);
                return RedirectToAction("Buy", new {buyerId = buyerLogin });
            }
            else return Content("errorValid");
        }
        public IActionResult Buy()
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            buyerManager.Buy(buyerLogin);
            return View();
        }
    }
}
