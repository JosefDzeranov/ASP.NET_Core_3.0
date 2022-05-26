using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productsRepository, IOrderRepository orderRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.orderRepository = orderRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Orders()
        {
            var orders = orderRepository.GetAll();
            if (orders == null || orders.Count == 0)
                return View("notFound");
            return View(orders);
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = orderRepository.TryGetById(orderId);
            return View(order);
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = productsRepository.GetAllProducts();
            return View(roles);
        }

        public IActionResult RemoveRole(string roleName)
        {
            //productsRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Roles");
            }
            return View(role);
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
