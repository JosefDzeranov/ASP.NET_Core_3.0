using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public static class CartManager
    {
        static List<Cart> cartList = new List<Cart>();



        public static Cart CreateCart()
        {
            Cart cart = new Cart(IdStorage.UserId);

            if (!cartList.Contains(cart))
            {
                cartList.Add(cart);
                cart = cartList.FirstOrDefault(x => x.UserId == cart.UserId);
            }
            else
            {
                cart = cartList.FirstOrDefault(x => x.UserId == cart.UserId);
            }

            return cart;
        }

        public static List<Cart> GetCarts()
        {
            return cartList;
        }

        public static void AddProductToCart(string userId, Product product)
        {

            if (cartList.FirstOrDefault(x => x.UserId == userId) != null)
            {
                var cart = cartList.FirstOrDefault(x => x.UserId == userId);

                if (cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id) != null)
                {
                    var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
                    cartLine.Amount++;
                }
                else
                {
                    var cartLine = new CartLine(product);
                    cartLine.Amount++;
                    cart.CartLines.Add(cartLine);
                }

            }
            else
            {
                var cart = CreateCart();

                cart.CartLines.Add(new CartLine(product));
                var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
                cartLine.Amount++;



            }



        }




    }


}
