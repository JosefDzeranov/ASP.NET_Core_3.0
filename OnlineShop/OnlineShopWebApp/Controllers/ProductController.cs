using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.DataSources;

namespace OnlineShopWebApp.Controllers
{
	public class ProductController : Controller
    {
        private readonly ProductDataSource productDataSource;
      public ProductController()
		{
            productDataSource = new ProductDataSource();
		}
        public IActionResult Index(int id)
        {
      
            var product = productDataSource.GetProductById(id);
                return View(product);

        }
    }
}
