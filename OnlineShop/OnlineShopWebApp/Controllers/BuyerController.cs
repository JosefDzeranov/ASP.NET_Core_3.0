using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{

    public class BuyerController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public BuyerController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index(Guid personId)
        {
            personId = MyConstant.DefaultBuyerIdIsNull(personId);
            return View(buyerStorage.FindBuyer(personId));
        }
    }
}
