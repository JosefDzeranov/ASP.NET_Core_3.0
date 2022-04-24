using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{

    public class OrderController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public OrderController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        [HttpPost]
        public IActionResult Index(int buyerId)
        {
            return View(buyerStorage.FindBuyer(buyerId));
        }

        public IActionResult ReportTransaction(int buyerId)
        {
            buyerStorage.ReportTransaction(buyerId);
            return View(); 
        }

        public IActionResult Buy()
        {
            throw new System.NotImplementedException();
        }
    }
}
