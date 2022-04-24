using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OOnlineShopWebApp.Controllers
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
