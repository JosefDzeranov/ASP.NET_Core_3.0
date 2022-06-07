using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;

        private readonly IOrdersStorage ordersStorage;

        private readonly IRoleStorage roleStorage;

        public AdminController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRoleStorage roleStorage)
        {
            this.productsStorage = productsStorage;

            this.ordersStorage = ordersStorage;

            this.roleStorage = roleStorage;
        }

        public IActionResult Orders()
        {
            var orders = ordersStorage.TryGetAllOrders();
            return View(orders);
        }

        public IActionResult Customers()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = roleStorage.GetAll();
            return View(roles);
        }

        public IActionResult Products()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }

        public IActionResult EditProduct(int productId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var product = productsStorage.TryGetProduct(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productsStorage.SaveEditedProduct(product);
            }

            return View();
        }

        public IActionResult DeleteProduct(int productId)
        {
            productsStorage.Delete(productId);

            return RedirectToAction("Products");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productsStorage.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult GetOrder(Guid id)
        {
            //SelectList state = new SelectList(OrderState , "Order", "State");
            //ViewBag.OrderState = state;
            var order = ordersStorage.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult SaveEditedOrder(Guid orderId, OrderState state)
        {
            ordersStorage.SaveEditedOrder(orderId, state);
            return RedirectToAction("GetOrder","Admin", new { orderId });
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (roleStorage.TryGet(role.Name) != null)
            {
                ModelState.AddModelError("", "Роль с таким именем уже имеется");
            }
            if (ModelState.IsValid)
            {
                roleStorage.Add(role);
                return RedirectToAction("Roles", "Admin");
            }

            return View(role);
        }
        public IActionResult DeleteRole(string name)
        {
            roleStorage.Remove(name);

            return RedirectToAction("Roles", "Admin");
        }
    }
}