using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class Cart
    {
        public static List<Product> addedProducts = new List<Product>();

        public static void AddProductToCart(Product product)
        {
            if (product != null)
            {
                addedProducts.Add(product);
            }
           
        }

        public static List<Product> GetAllCartProducts()
        {
            return addedProducts;
        }
    }
}
