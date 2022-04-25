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

        public IActionResult Index()
        {

            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

        public IActionResult DeleteProduct(int id)
        {
            var product = productRepository.TryGetById(id);
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Products", "Admin");
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


            return RedirectToAction("Products", "Admin");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.Add(product);
            return RedirectToAction("Products", "Admin");
        }

=======
>>>>>>> karpunin_lesson5_4
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
<<<<<<< HEAD
            var products = productRepository.GetAll();

            return View(products);
        }

=======
            return View();
        }
>>>>>>> karpunin_lesson5_4
=======
>>>>>>> parent of f662e62 (adding partial view adminLeftPanel and view methods into AdminController)
=======
>>>>>>> parent of f662e62 (adding partial view adminLeftPanel and view methods into AdminController)
    }
}
