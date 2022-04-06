using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        private static List<CartItem> CartItems { get; set; } = new List<CartItem>();
        private readonly ProdcutBase prodcutBase = new ProdcutBase();
        private static decimal TotalCost { get; set; }
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
                TotalCost += cartItem.Product.Cost;
                CartItems.Add(cartItem);
            }
            else
            {
                TotalCost += cartItem.Product.Cost;
                cartItem.Quantinity++;
            }

            
        }

        public decimal GetTotalCost()
        {
            return TotalCost;
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
