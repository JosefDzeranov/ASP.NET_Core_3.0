using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public  class CartManager
    {
        static List<Cart> cartList = new List<Cart>();



        public Cart CreateCart()
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

        public List<Cart> GetCarts()
        {
            return cartList;
        }

        public  void AddProductToCart(string userId, Product product)
        {

            if (cartList.FirstOrDefault(x => x.UserId == userId) != null)
            {
               var cart = cartList.FirstOrDefault(x => x.UserId == userId);

                if (cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id) != null)
                {
                  var  cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
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
                cartList.Add(cart);
                var cartLine = new CartLine(product);
                
                cartLine.Amount++;
                cart.CartLines.Add(cartLine);


            }



        }

        public Cart TryGetCartByUserID(string userId)
        {
            if (cartList.FirstOrDefault(x => x.UserId == userId) != null)
            {
                return cartList.FirstOrDefault(x => x.UserId == userId);
            }
            else
            {
                return null;
            }
        }

       


    }


}
