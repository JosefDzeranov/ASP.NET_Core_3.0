using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OOnlineShopWebApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IBuyerStorage buyerStorage;
        private readonly IRolesStorage rolesStorage;
        public AdminPanelController(IProductStorage productStorage, IBuyerStorage buyerStorage, IRolesStorage rolesStorage)
        {
            this.productStorage = productStorage;
            this.buyerStorage = buyerStorage;
            this.rolesStorage = rolesStorage;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = buyerStorage.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = rolesStorage.GetAll();
            return View(roles);
        }
        public IActionResult Products()
        {
            var products = productStorage.Products;
            return View(products);
        }
        public IActionResult DeleteProduct(Guid productId)
        {
            var product = productStorage.FindProduct(productId);
            productStorage.DeleteProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult CardUpdateProduct(Guid productId)
        {
            var oldProduct = productStorage.FindProduct(productId);
            return View(oldProduct);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.UpdateProduct(product);
                return RedirectToAction("Products");
            }
            else return Content("errorValid");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.AddNewProduct(product);
                return RedirectToAction("Products");
            }
            return Content("errorValid");
        }
        public IActionResult DetailsOrder(Guid orderId)
        {
            var order = buyerStorage.FindOrderItem(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetailsOrder(OrderItem newOrder)
        {
            buyerStorage.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("DetailsOrder", new { orderId });
        }

        public IActionResult RemoveRole(string roleName)
        {
            rolesStorage.Remove(roleName);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesStorage.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesStorage.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
    }
}
