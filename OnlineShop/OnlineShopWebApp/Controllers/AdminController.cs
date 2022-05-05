using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IAdminPanelRepository adminPanelRepository;

        public AdminController(IProductsRepository productsRepository, IOrderRepository orderRepository, IAdminPanelRepository adminPanelRepository)
        {
            this.productsRepository = productsRepository;
            this.orderRepository = orderRepository;
            this.adminPanelRepository = adminPanelRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Clear(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            adminPanelRepository.Clear(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Changes(int productId)
        {
            var product = productsRepository.TryGetByid(productId);

            return View(product);
        }
    }
}
