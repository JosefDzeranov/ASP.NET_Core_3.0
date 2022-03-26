using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public static class ProductManager
    {
       private static List<Product> productList = new List<Product>()
        {
            new Product(1, "Cheeseburger", 150, "бургер с говяжьей котлетой и сыром"),
            new Product(2, "Hamburger", 120, "бургер с говяжьей котлетой"),
            new Product(3, "Bigburger", 200, "бургер с двойной говяжьей котлетой")
        };

        public static string ShowProducts()
        {
            string output = string.Empty;
            foreach (var product in productList)
            {
                output += $"{product.Id}\n{product.Cost}\n{product.Description}\n\n";
            }
            return output;
        }

        public static string FindProduct(int id)
        {
            string foundProduct = string.Empty;

            foreach (var product in productList)
            {
                if (product.Id == id)
                {
                    foundProduct += $"{product.Id}\n{product.Cost}\n{product.Description}";
                }
            }

            return foundProduct;
        }
    }
}
