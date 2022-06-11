using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrderController : Controller
    {
        private readonly IBuyerManager _buyerManager;
        private readonly IUserManager _userManager;
        public OrderController(IBuyerManager buyerManager, IUserManager userManager)
        {
            _buyerManager = buyerManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            return View(_buyerManager.FindBuyer(buyerLogin));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _buyerManager.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new {buyerId = buyerLogin });
        }

        [HttpPost]
        public IActionResult BuyValid(InfoBuying infoBuying)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            if (ModelState.IsValid)
            {
                _buyerManager.SaveInfoBuying(infoBuying, buyerLogin);
                return RedirectToAction("Buy", new {buyerId = buyerLogin });
            }
            else return Content("errorValid");
        }
        public IActionResult Buy()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _buyerManager.Buy(buyerLogin);
            return View();
        }
    }
}
