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
              Cart cart = new Cart(Constants.UserId);

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
            var cart = cartList.FirstOrDefault(x => x.UserId == userId);
            var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);

            if (cart != null)
            {
             

                if (cartLine != null)
                {
                 
                  cartLine.Amount++;
                }
                else
                {
                    cartLine = new CartLine(product);
                    cartLine.Amount++;
                    cart.CartLines.Add(cartLine);
                }

            }
            else
            {
                cart = CreateCart();
                cartList.Add(cart);
                cartLine = new CartLine(product);
                
                cartLine.Amount++;
                cart.CartLines.Add(cartLine);


            }



        }

        public Cart TryGetCartByUserID(string userId)
        {
            return cartList.FirstOrDefault(x => x.UserId == userId);

           
        }

       


    }


}
