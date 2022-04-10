using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productsRepository;
        private readonly Constants constants;


        public CartController(ProductsRepository productsRepository, Constants constants)
        {
            this.productsRepository = productsRepository;
            this.constants = constants;
        }

        public IActionResult Index()
        {
            var cart = CartRepository.TryGetByUserId(constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            CartRepository.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
