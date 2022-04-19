using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class BuyerController : Controller
    {
        private readonly IBuyerStorage buyerCatalog;
        public BuyerController(IBuyerStorage buyerCatalog)
        {
            this.buyerCatalog = buyerCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(buyerCatalog.FindPerson(personId));
        }

    }
}
