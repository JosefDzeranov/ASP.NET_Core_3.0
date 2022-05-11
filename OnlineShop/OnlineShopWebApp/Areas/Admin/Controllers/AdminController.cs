using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IRoleStorage _roleStorage;
        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, IRoleStorage roleStorage)
        {
            _productStorage = productStorage;
            _orderStorage = orderStorage;
            _roleStorage = roleStorage;
        }
        public IActionResult Orders()
        {
            var orders = _orderStorage.GetOrderData();
            if (orders.Count == 0)
            {
                return View("EmptyOrders");
            }
            return View (orders);
        }

        public IActionResult OrderDetails(Guid id)
        {
            var order = _orderStorage.TryGetById(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid id, OrderStatus status)
        {
            _orderStorage.UpdateStatus(id, status);
            return RedirectToAction("Orders");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = _roleStorage.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(string name)
        {
            if(ModelState.IsValid)
            {
                _roleStorage.AddRole(name);
                return RedirectToAction("Roles");
            }
            return View();
        }

        public IActionResult EditRole(string name)
        {
            var role = _roleStorage.TryGetRoleByName(name);
            return View(role);
        }

        [HttpPost]
        public IActionResult SaveRole(string oldName, Role role)
        {
            if(ModelState.IsValid)
            {
                _roleStorage.EditRole(oldName, role);
                return RedirectToAction("Roles");
            }
            return View();
        }

        public IActionResult RemoveRole(string name)
        {
            _roleStorage.RemoveRole(name);
            return RedirectToAction("Roles");
        }

        public IActionResult Products()
        {
            var products = _productStorage.GetProductData();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.AddProduct(product);
                return RedirectToAction("Products");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.EditProduct(product);
                return RedirectToAction("Products");
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            _productStorage.RemoveProduct(id);
            return RedirectToAction("Products"); ;
        }
    }
}
