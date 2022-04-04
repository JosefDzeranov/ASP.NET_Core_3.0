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
            var product = productRepository.GetById(id);
        }
    }
}
