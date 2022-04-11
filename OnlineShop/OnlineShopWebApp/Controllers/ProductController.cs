using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private DataStorage Data { get; }
        public ProductController(DataStorage dataStorage)
        {
            Data = dataStorage;
        }
        public IActionResult Index(int id)
        {
            var product = Data.TryGetProduct(id);              
            return View(product);
        }
    }
}
