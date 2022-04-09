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
            Cart cart = new Cart();

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

        public static void  AddProductToCart(Cart cart, Product product)
        {
            if (cart.AddedProducts.Contains(product))
            {

                foreach (var item in cart.AddedProducts)
                {
                    if (item == product)
                    {
                        item.Number++;
                        item.TotalCost += item.Cost;

                    }
                }

            }
            else
            {
                product.Number++;
                cart.AddedProducts.Add(product);
            }
        }
       



    }


}
