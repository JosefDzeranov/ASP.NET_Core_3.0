using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Controllers
{

    public class OrderController : Controller
    {
        private readonly IBuyerManager buyerManager;
        public OrderController(IBuyerManager buyerManager)
        {
            this.buyerManager = buyerManager;
        }

        public IActionResult Index(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            return View(buyerManager.FindBuyer(buyerId));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerManager.ClearInfoBuying(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        [HttpPost]
        public IActionResult BuyValid(InfoBuying infoBuying, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            if (ModelState.IsValid)
            {
                buyerManager.SaveInfoBuying(infoBuying, buyerId);
                return RedirectToAction("Buy", new { buyerId });
            }
            else return Content("errorValid");
        }
        public IActionResult Buy(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerManager.Buy(buyerId);
            return View();
        }
    }
}
