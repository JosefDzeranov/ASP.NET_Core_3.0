using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public static List<CartItem> CartItems { get; set; } = new List<CartItem>();
        private readonly ProdcutBase prodcutBase = new ProdcutBase();
        public void AddToCart(int id)
        {
            var cartItem = CartItems.SingleOrDefault(cartItem => cartItem.Product.Id == id);
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    Product = prodcutBase.TryGetById(id),
                    Quantinity = 1

                };
                CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantinity++;
            }

            
        }

        public List<CartItem> TryGetAll()
        {
            return CartItems ?? null;
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }
    }
}
