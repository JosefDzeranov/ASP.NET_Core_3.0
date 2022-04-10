using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public  class CartManager
    {
        static List<Cart> cartList = new List<Cart>();
        public  Cart cart = new Cart(IdStorage.UserId);
        private  CartLine cartLine;

        //public  Cart CreateCart()
        //{
        //  //  Cart cart = new Cart(IdStorage.UserId);

        //    if (!cartList.Contains(cart))
        //    {
        //        cartList.Add(cart);
        //        cart = cartList.FirstOrDefault(x => x.UserId == cart.UserId);
        //    }
        //    else
        //    {
        //        cart = cartList.FirstOrDefault(x => x.UserId == cart.UserId);
        //    }

        //    return cart;
        //}

        public  List<Cart> GetCarts()
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
                    var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
                    cartLine.Amount++;
                }
                else
                {
                    cartLine.Product = product;
                    cartLine.Amount++;
                    cart.CartLines.Add(cartLine);
                }

            }
            else
            {
               // var cart = CreateCart();

                cart.CartLines.Add(new CartLine(product));
                cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
                cartLine.Amount++;



            }



        }

        //public CartManager(Cart cart, CartLine cartLine)
        //{
        //    this.cart = cart;
        //    this.cartLine = cartLine;
        //}


    }


}
