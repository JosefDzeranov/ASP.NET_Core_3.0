using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;

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

        public IActionResult Orders()
        {

            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }

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
        public IActionResult EditProduct(Product changingProduct)
        {


            productRepository.Update(changingProduct);


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

            var products = productRepository.GetAll();

            return View(products);
        }
        public IActionResult OrderDetail(Guid orderId)
        {
            if(orderId != null)
            {
                var order = orderRepository.TryGetById(orderId);

                return View(order);
            }
            return RedirectToAction("Products", "Admin");
        }
        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(orderId, status);

            return RedirectToAction("OrderDetail","Admin", new { orderId });
        }

    }
}
