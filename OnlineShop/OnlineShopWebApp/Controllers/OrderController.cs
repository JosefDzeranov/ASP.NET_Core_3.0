using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{

    public class OrderController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public OrderController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        public IActionResult Index(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            return View(buyerStorage.FindBuyer(buyerId));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerStorage.ClearInfoBuying(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        [HttpPost]
        public IActionResult BuyValid(InfoBuying infoBuying, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            if (ModelState.IsValid)
            {
                buyerStorage.SaveInfoBuying(infoBuying, buyerId);
                return RedirectToAction("Buy", new { buyerId });
            }
            else return Content("errorValid");
        }
        public IActionResult Buy(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerStorage.Buy(buyerId);
            return View();
        }
    }
}
