using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;

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
            return View(Mapping.ToProductViewModel(product));
        }

    }
}
