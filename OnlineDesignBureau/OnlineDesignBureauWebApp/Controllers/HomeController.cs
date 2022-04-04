using Microsoft.AspNetCore.Mvc;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog _productCatalog;
        public HomeController()
        {
            _productCatalog = new ProductCatalog();
        }
        public string Index()
        {
            return _productCatalog.ReadDataProducts();
        }
    }
}
