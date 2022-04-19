using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonCatalog personCatalog;
        private readonly ProductCatalog productCatalog;
        public HomeController(ProductCatalog productCatalog, PersonCatalog personCatalog)
        {
            this.productCatalog = productCatalog;
            this.personCatalog = personCatalog;
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
