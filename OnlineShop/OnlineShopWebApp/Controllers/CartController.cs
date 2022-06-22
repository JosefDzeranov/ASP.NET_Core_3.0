using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var cart = cartsRepository.TryGetByUserId(user.Id);
            return View(Mapping.ToCartViewModel(cart));
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            cartsRepository.Add(product, user.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid itemId)
        {
            var product = productsRepository.TryGetById(itemId);
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            cartsRepository.Delete(product, user.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            cartsRepository.Clear(user.Id);
            return RedirectToAction("Index");
        }
    }
}
