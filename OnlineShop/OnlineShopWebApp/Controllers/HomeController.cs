using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Models;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog productCatalog;
        //private readonly PersonCatalog personCatalog;
        public HomeController()
        {
            productCatalog = new ProductCatalog();
        }
        public IActionResult Index()
        {
            if (ProductCatalog.products.Count == 0)
                productCatalog.ReadToJson();
            if (PersonCatalog.persons.Count == 0)
            {
                Person person = new Person(0, "Александр", "Молостов", 30, "email", "111111");
                PersonCatalog.persons.Add(person);
            }
            return View(ProductCatalog.products);
        }
    }
}
