using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrderController : Controller
    {
        private readonly IOrdersManager _orderManager;
        private readonly ICartsManager _cartsManager;
        private readonly IUsersManager _usersManager;
        public OrderController(IOrdersManager orderManager, IUsersManager usersManager, ICartsManager cartsManager)
        {
            _orderManager = orderManager;
            _usersManager = usersManager;
            _cartsManager = cartsManager;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            return View(_usersManager.Find(buyerLogin));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsManager.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new {buyerId = buyerLogin });
        }

        [HttpPost]
        public IActionResult BuyValid(UserDeleveryInfo_ViewModel userDeleveryInfo)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            if (ModelState.IsValid)
            {
                _cartsManager.SaveInfoBuying(userDeleveryInfo, buyerLogin);
                return RedirectToAction("Buy", new {buyerId = buyerLogin });
            }
            return Content("errorValid");
        }
        public IActionResult Buy()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _orderManager.Buy(buyerLogin);
            return View();
        }
    }
}
