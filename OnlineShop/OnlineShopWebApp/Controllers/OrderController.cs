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

        public IActionResult Index(int buyerId)
        {
            return View(buyerStorage.FindBuyer(buyerId));
        }
        [HttpPost]
        public IActionResult SaveInfoBuying(InfoBuying infoBuying, int buyerId)
        {
            if (ModelState.IsValid)
            {
                buyerStorage.SaveInfoBuying(infoBuying, buyerId);
                return RedirectToAction("Index", new { buyerId });
            }
            else return Content("errorValid");
        }
        public IActionResult RewriteInfoBuying(int buyerId)
        {
            buyerStorage.ClearInfoBuying(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult Buy(int buyerId)
        {
            buyerStorage.Buy(buyerId);
            return View(); 
        }



    }
}
