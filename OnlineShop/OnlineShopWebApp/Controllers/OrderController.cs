using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrderController : Controller
    {
        private readonly IOrdersRepositiry _ordersRepositiry;
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersManager _usersManager;
        public OrderController(IOrdersRepositiry ordersRepositiry, IUsersManager usersManager, ICartsRepository cartsRepository)
        {
            _ordersRepositiry = ordersRepositiry;
            _usersManager = usersManager;
            _cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var cart = _cartsRepository.Find(buyerLogin);
            return View(Mapping.ToCart_ViewModel(cart));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsRepository.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new {buyerId = buyerLogin });
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying(UserDeleveryInfo_ViewModels userDeleveryInfoViewModels)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var userDelevery = Mapping.ToUserDeleveryInfo(userDeleveryInfoViewModels);
            _cartsRepository.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new { buyerId = buyerLogin });
        }

        [HttpPost]
        public IActionResult BuyValid(UserDeleveryInfo userDeleveryInfo)
        {
            userDeleveryInfo.Id = Guid.NewGuid();
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            if (ModelState.IsValid)
            {
                _cartsRepository.SaveInfoBuying(userDeleveryInfo, buyerLogin);
                return RedirectToAction("Buy", new {buyerId = buyerLogin });
            }
            return Content("errorValid");
        }
        public IActionResult Buy()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _ordersRepositiry.Buy(buyerLogin);
            return View();
        }
    }
}
