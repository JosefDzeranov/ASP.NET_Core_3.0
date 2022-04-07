using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public static class CartManager
    {
        static List<Cart> cartList = new List<Cart>();

        static Cart currentCart { get; set; }

        public static void AddCart(Cart cart)
        {
            foreach (var item in cartList)
            {
                if (cart.Id != item.Id)
                {
                    cartList.Add(cart);
                }
            }
        }

        public static void AddProductToCart(Cart cart)
        {

            foreach (var item in cartList)
            {

                if (cart.Id == item.Id)
                {



                }

            }

        }



    }

    
}
