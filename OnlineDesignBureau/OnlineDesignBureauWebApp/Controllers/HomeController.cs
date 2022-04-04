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
        public string Index()
        {
            return productCatalog.ReadDataProducts();
        }
    }
}
