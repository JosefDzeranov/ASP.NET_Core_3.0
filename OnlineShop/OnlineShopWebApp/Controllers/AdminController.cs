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
            var admPanel = adminPanelRepository.TryGetByUserId(Constants.UserId);
            return View(admPanel);
        }

        public IActionResult Users()
        {
            var admPanel = adminPanelRepository.TryGetByUserId(Constants.UserId);
            return View(admPanel);
        }

        public IActionResult Roles()
        {
            var admPanel = adminPanelRepository.TryGetByUserId(Constants.UserId);
            return View(admPanel);
        }

        public IActionResult Products()
        {
            var admPanel = adminPanelRepository.TryGetByUserId(Constants.UserId);
            return View(admPanel);
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
