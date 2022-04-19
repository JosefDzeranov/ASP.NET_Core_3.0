using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productCatalog;
        private readonly IBuyerStorage buyerCatalog;
        public HomeController(IBuyerStorage buyerCatalog, IProductStorage productCatalog)
        {
            this.buyerCatalog = buyerCatalog;
            this.productCatalog = productCatalog;
        }
        public IActionResult Index()
        {
            if (productCatalog.Products.Count == 0)
                productCatalog.ReadToStorage();
            if (buyerCatalog.Persons.Count == 0)
                buyerCatalog.ReadToStorage();
            return View(productCatalog.Products);
        }
    }
}
