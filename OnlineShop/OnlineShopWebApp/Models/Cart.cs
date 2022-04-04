using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class Cart
    {
        public static List<Product> addedProducts = new List<Product>();

        public static void AddProductToCart(Product product)
        {
           

            if (addedProducts.Contains(product))
            {
              
                foreach (var item in addedProducts)
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
                addedProducts.Add(product);
            }
           
        }

        public static List<Product> GetAllCartProducts()
        {
            return addedProducts;
        }
    }
}
