using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;

        public IActionResult Index(int id)
        {
            var foundProduct = productManager.FindProduct(id);
            return View(foundProduct);
        }

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }
    }


}
