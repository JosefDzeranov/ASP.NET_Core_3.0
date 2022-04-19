using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class BuyerController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public BuyerController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index(int personId)
        {
            return View(buyerStorage.FindBuyer(personId));
        }
    }
}
