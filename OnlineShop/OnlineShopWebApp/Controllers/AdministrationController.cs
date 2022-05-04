using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IOrderManager orderManager;

        public AdministrationController(IProductManager productManager, IOrderManager orderManager)
        {
            this.productManager = productManager;
            this.orderManager = orderManager;
        }

        public IActionResult Index()
        {

            return RedirectToAction("Orders");
        }

        public IActionResult Orders()
        {
            var ordersList = orderManager.GetOrders();

            return View(ordersList);

        }

        public IActionResult EditOrder(Guid id)
        {
            var order = orderManager.TryGetOrderById(id);

            return View(order);

        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid id, OrderStatus status)
        {

            orderManager.UpdateStatus(id, status);
            return RedirectToAction("Orders");

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
            var productList = productManager.ProductList;
            return View(productList);
        }

        public IActionResult EditProduct(int id)
        {
            var product = productManager.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                productManager.EditProduct(product);

                return View();
            }
            else
            {
                return RedirectToAction("EditProduct");
            }

        }

        public IActionResult RemoveProduct(int id)
        {
            var product = productManager.FindProduct(id);
            productManager.ProductList.Remove(product);
            return View(product);
        }

        public IActionResult AddNewProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.ProductList.Add(product);

                return View(product);
            }
            else
            {
                return RedirectToAction("AddNewProduct");
            }

        }
    }

}