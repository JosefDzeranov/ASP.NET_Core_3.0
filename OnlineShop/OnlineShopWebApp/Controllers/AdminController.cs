using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrderRepository orderRepository;

        public AdminController(IProductsRepository productsRepository, IOrderRepository orderRepository)
        {
            this.productsRepository = productsRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Orders()
        {
            var orders = orderRepository.GetAll();
            if (orders == null || orders.Count == 0)
                return View("notFound");
            return View();
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = orderRepository.TryGetById(orderId);
            return View(order);
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
            var products = productsRepository.GetAllProducts();
            if (products == null || products.Count == 0)
                return View("notFound");
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid == false)
                return View(product);
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid == false)
                return View(product);
            productsRepository.Edit(product);
            return RedirectToAction("Products");
        }

        public IActionResult Clear(int productId)
        {
            productsRepository.Clear(productId);
            return RedirectToAction("Products");
        }
    }
}
