using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;

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
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index", "Admin", new { id = 3 });
        }

        public IActionResult EditProduct(int id)
        {
            var product = productRepository.TryGetById(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {

            var product = productRepository.TryGetById(productViewModel.ProductId);

            product.Name = productViewModel.Name;
            product.Cost = productViewModel.Cost;
            product.Description = productViewModel.Description;
            product.ImgPath = productViewModel.ImgPath;

            productRepository.Update(product);


            return RedirectToAction("Index", "Admin", new { id = 3 });
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.Add(product);
            return RedirectToAction("Index", "Admin", new { id = 3 });
        }
    }
}
