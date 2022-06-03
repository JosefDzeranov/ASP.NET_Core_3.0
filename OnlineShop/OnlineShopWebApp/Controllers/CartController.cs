using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;
using OnlineShop.DB;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.DB.Models;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopWebApp.Controllers
{

    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;
        private readonly UserManager<User> userManager;
        private readonly ITempUserRepository tempUserRepository;
        public CartController(IProductRepository productRepository, ICartRepository cartRepository, UserManager<User> userManager, ITempUserRepository tempUserRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.userManager = userManager;
            this.tempUserRepository = tempUserRepository;

        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var cartDb = cartRepository.TryGetByUserId(userId);
            if (cartDb != null)
            {
                var cartViewModel = cartDb.MappingToCartViewModel();
                return View(cartViewModel);
            }

            return View();
        }

        public IActionResult Add(Guid productId)
        {
            var userId = GetUserId();
            var product = productRepository.TryGetById(productId);
            cartRepository.Add(product, userId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var userId = GetUserId();
            cartRepository.RemoveItem(productId, userId);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {
            var userId = GetUserId();
            cartRepository.Clear(userId);

            return RedirectToAction("Index");
        }

        private string GetUserId()
        {
            string userId;
            if (IsAuthenticated())
            {
                userId = userManager.GetUserAsync(HttpContext.User).Result.Id;
            }
            else
            {
                if (HttpContext.Request.Cookies.ContainsKey("tempId"))
                {
                    userId = HttpContext.Request.Cookies["tempId"];
                }
                else
                {
                    var TempUser = new TempUser();
                    tempUserRepository.Add(TempUser);
                    userId = TempUser.Id.ToString();
                    HttpContext.Response.Cookies.Append("tempId", userId);
                }
            }
            return userId;
        }

        private bool IsAuthenticated()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }
    }
}
