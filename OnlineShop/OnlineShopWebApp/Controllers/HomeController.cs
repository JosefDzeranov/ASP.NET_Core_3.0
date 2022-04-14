using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public HomeController()
        {
            productCatalog = new ProductCatalog();
        }
        public IActionResult Index()
        {
            if (ProductCatalog.products.Count == 0)
                productCatalog.ReadToJson();
            if (PersonCatalog.persons.Count == 0)
                PersonCatalog.ReadToJson();
            return View(ProductCatalog.products);
        }
    }
}
