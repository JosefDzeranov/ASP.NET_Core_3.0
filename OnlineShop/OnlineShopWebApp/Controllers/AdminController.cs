using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        public AdminController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {

            return View(id);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = productRepository.TryGetById(id);
            if(product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index", "Admin",new { id = 3 });
        }


    }
}
