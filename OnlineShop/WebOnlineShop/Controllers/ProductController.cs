using Microsoft.AspNetCore.Mvc;

namespace WebOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        public string Index(int id)
        {
            var product = productRepository.TryGetById(id);
            if (product == null)
            {
                return $"Продукта с таким id={id} не существует";
            }
            return $"{product}\n{product}";
        }
    }
}
