using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetByid(id);
            return View(product);

            //if (product == null)
            //    return $"Продукта с таким id = {id} не существует!";
            //return $"{product}";
        }
    }
}
