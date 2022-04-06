using Microsoft.AspNetCore.Mvc;

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
                productCatalog.ReadToJson("projects_for_sale");
            return View(ProductCatalog.products);
        }
    }
}
