using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog productCatalog;
        private readonly PersonCatalog personCatalog;
        public HomeController(PersonCatalog personCatalog, ProductCatalog productCatalog)
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
