using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IBuyerManager buyerManager;
        private readonly IProductStorage productStorage;
        public CartController(IBuyerManager buyerManager, IProductStorage productStorage)
        {
            this.buyerManager = buyerManager;
            this.productStorage = productStorage;
        }
        public IActionResult Index(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            return View(buyerManager.FindBuyer(buyerId));
        }

        public IActionResult AddProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            var product = productStorage.FindProduct(productId);
            buyerManager.AddProductInCart(product, buyerId);
            return RedirectToAction("Index", new {buyerId});
        }

        public IActionResult DeleteProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerManager.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerManager.ReduceDuplicateProductCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult Clear(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerManager.ClearCart(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
    }


}
