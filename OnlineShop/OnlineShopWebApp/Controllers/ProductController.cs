using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDataSource productDataSource;
        public ProductController(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }

        public IActionResult Index(int id)
        {
            var product = productDataSource.GetProductById(id);
            return View(product);
        }

    }
}
