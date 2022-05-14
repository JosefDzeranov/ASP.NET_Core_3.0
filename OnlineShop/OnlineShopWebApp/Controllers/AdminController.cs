﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductBase _productBase;
        private readonly IOrderBase _orderBase;


        public AdminController(IProductBase productBase, IOrderBase orderBase)
        {
            _productBase = productBase;
            _orderBase = orderBase;
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
            var products = _productBase.AllProducts();
            return View(products);
        }

        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productBase.Add(product);
                return RedirectToAction("Products", "Admin");
            }
            else
            {
                return View("AddNewProduct");
            }

        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var product = _productBase.TryGetById(productId);
            return View(product);
        }

        

        [HttpPost]
        public IActionResult UpdateStatusOrder(int orderId, OrderStatus status)
        {
            _orderBase.UpdateOrderStatus(orderId, status);
            return RedirectToAction("Orders");
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productBase.Edit(product);
                return RedirectToAction("products", "admin");
            }
            else
            {
                return View("EditProduct", product);
            }

        }

        public IActionResult DeleteProduct(int productId)
        {
            _productBase.Delete(productId);
            return RedirectToAction("products", "admin");
        }
    }
}
