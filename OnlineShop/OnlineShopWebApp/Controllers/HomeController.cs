using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productCatalog;
        private readonly IPersonStorage personCatalog;
        public HomeController(IPersonStorage personCatalog, IProductStorage productCatalog)
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
