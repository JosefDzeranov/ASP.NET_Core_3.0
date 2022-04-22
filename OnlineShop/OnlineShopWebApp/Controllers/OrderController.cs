using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
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

        public IActionResult ReportTransaction(int buyerId)
        {
            buyerStorage.ReportTransaction(buyerId);
            return View();
        }
    }
}
