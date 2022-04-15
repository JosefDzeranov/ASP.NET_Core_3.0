using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartManager : ICartManager
    {
        static List<Cart> cartList = new List<Cart>();



        public Cart CreateCart()
        {
            var cart = new Cart(Constants.UserId);

            if (cartList.Count == 0)
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

        public void AddProductToCart(string userId, Product product)
        {
            var cart = cartList.FirstOrDefault(x => x.UserId == userId);


            if (cart != null)
            {



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

                cart = CreateCart();
                cartList.Add(cart);
                var cartLine = new CartLine(product);

                cartLine.Amount++;
                cart.CartLines.Add(cartLine);


            }



        }

        public void RemoveProductFromCart(string userId, Product product)
        {
            var cart = cartList.FirstOrDefault(x => x.UserId == userId);
            var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            cartLine.Amount--;

            if (cartLine.Amount <= 0)
            {
                cart.CartLines.Remove(cartLine);
            }

        }



        public Cart TryGetCartByUserID(string userId)
        {
            return cartList.FirstOrDefault(x => x.UserId == userId);


        }


    }


}
