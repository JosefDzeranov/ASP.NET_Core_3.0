using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartManager cartManager;

        public CartViewComponent(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            var productCount = cart?.Amount ?? 0;

            if (cart == null || cart.CartLines.Count == 0)
            {
                return View("EmptyCart", " ");
            }
            else
            {
                return View("Cart", productCount);
            }
            

            
               
           
        }
           
    }

}