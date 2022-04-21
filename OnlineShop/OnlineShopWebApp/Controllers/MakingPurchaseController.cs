using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class MakingPurchaseController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public MakingPurchaseController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index(int buyerId)
        {
            return View(buyerStorage.FindBuyer(buyerId));
        }
    }
}
