using Microsoft.AspNetCore.Mvc;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public PersonController()
        {
            productCatalog = new ProductCatalog();
        }
        public IActionResult Index()
        {
            if (ProductCatalog.products.Count == 0)
                productCatalog.ReadToJson("projects_for_sale");
            return View(ProductCatalog.products);
        }
    }
}
