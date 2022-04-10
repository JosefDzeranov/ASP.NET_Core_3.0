using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class CartRepository
    {

        public static void Add(Product product)
        {
            if (Cart.CartItems.ContainsKey(product))
            {
                Cart.CartItems[product] += 1;
            }
            else
            {
                Cart.CartItems.Add(product, 1);
            }

        }

    }
}
