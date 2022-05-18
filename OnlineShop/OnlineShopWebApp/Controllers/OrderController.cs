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

        public IActionResult Index(string buyerLogin)
        {
            return View(buyerManager.FindBuyer(buyerLogin));
        }

        [HttpPost]

        public IActionResult RewriteInfoBuying(string buyerLogin)
        {
            buyerManager.ClearInfoBuying(buyerLogin);
            return RedirectToAction("Index", new {buyerId = buyerLogin });
        }

        [HttpPost]
        public IActionResult BuyValid(InfoBuying infoBuying, string buyerLogin)
        {
            if (ModelState.IsValid)
            {
                buyerManager.SaveInfoBuying(infoBuying, buyerLogin);
                return RedirectToAction("Buy", new {buyerId = buyerLogin });
            }
            else return Content("errorValid");
        }
        public IActionResult Buy(string buyerLogin)
        {
            buyerManager.Buy(buyerLogin);
            return View();
        }
    }
}
