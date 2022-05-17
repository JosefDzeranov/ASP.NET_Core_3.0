using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{

    public class BuyerController : Controller
    {
        private readonly IBuyerManager buyerManager;
        public BuyerController(IBuyerManager buyerManager)
        {
            this.buyerManager = buyerManager;
        }
        public IActionResult Index(Guid personId)
        {
            personId = MyConstant.DefaultBuyerIdIsNull(personId);
            return View(buyerManager.FindBuyer(personId));
        }
    }
}
