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
        private readonly IRoleRepository roleRepository;
        public AdminController(IOrderRepository orderRepository, IProductRepository productRepository, IRoleRepository roleRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.roleRepository = roleRepository;
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
            if (ModelState.IsValid)
            {
                productRepository.Update(changingProduct);
            }

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
            var roles = roleRepository.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if(roleRepository.TryGetByName(role.Name)!= null)
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                roleRepository.Add(role);
                return RedirectToAction("Roles", "Admin");
            }

            return View(role);
        }
        public IActionResult DeleteRole(string name)
        {
            roleRepository.Remove(name);

            return RedirectToAction("Roles", "Admin");
        }
        public IActionResult Products()
        {

            var products = productRepository.GetAll();

            return View(products);
        }
        public IActionResult OrderDetail(Guid orderId)
        {
            if (orderId != null)
            {
                var order = orderRepository.TryGetById(orderId);

                return View(order);
            }
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(orderId, status);

            return RedirectToAction("OrderDetail", "Admin", new { orderId });
        }

    }
}
