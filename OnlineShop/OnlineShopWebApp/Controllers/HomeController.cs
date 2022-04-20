using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IBuyerStorage buyerStorage;
        public HomeController(IBuyerStorage buyerStorage, IProductStorage productStorage)
        {
            this.buyerStorage = buyerStorage;
            this.productStorage = productStorage;
        }
        public IActionResult Index()
        {
            if (productStorage.Products.Count == 0)
                productStorage.ReadToStorage();
            if (buyerStorage.Buyers.Count == 0)
                buyerStorage.ReadToStorage();
            return View(productStorage.Products);
        }

    }
}
