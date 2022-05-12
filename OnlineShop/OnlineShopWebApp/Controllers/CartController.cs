using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        private readonly IProductStorage productStorage;
        public CartController(IBuyerStorage buyerStorage, IProductStorage productStorage)
        {
            this.buyerStorage = buyerStorage;
            this.productStorage = productStorage;
        }
        public IActionResult Index(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            return View(buyerStorage.FindBuyer(buyerId));
        }

        public IActionResult AddProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            var product = productStorage.FindProduct(productId);
            buyerStorage.AddProductInCart(product, buyerId);
            return RedirectToAction("Index", new {buyerId});
        }

        public IActionResult DeleteProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerStorage.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId, Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerStorage.ReduceDuplicateProductCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult Clear(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            buyerStorage.ClearCart(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
    }


}
