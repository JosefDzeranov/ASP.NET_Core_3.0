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
        public IActionResult ReportTransaction(int buyerId)
        {
            buyerStorage.FindBuyer(buyerId).OrdersList.AddRange(buyerStorage.FindBuyer(buyerId).CartList);
            buyerStorage.FindBuyer(buyerId).CartList.Clear();
            buyerStorage.WriteToStorage();
            return View();
        }
    }
}
