using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductMemoryStorage productCatalog;
        private readonly IPersonMemoryStorage personCatalog;
        public HomeController(IPersonMemoryStorage personCatalog, IProductMemoryStorage productCatalog)
        {
            this.personCatalog = personCatalog;
            this.productCatalog = productCatalog;
        }
        public IActionResult Index()
        {
            if (productCatalog.Products.Count == 0)
                productCatalog.ReadToStorage();
            if (personCatalog.Persons.Count == 0)
                personCatalog.ReadToStorage();
            return View(productCatalog.Products);
        }
    }
}
