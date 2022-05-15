using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IOrdersStorage ordersStorage;

        public AdminController(IProductsStorage productsStorage, IOrdersStorage ordersStorage)
        {
            this.productsStorage = productsStorage;

            this.ordersStorage = ordersStorage;
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
            return View();
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
            productsStorage.SaveEditedProduct(product);
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
    }
}