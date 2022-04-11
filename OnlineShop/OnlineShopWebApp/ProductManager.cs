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
            var output = string.Empty;
            foreach (var product in productList)
            {
                output += $"{product.Id}\n{product.Name}\n{product.Cost}\n\n";
            }
            return output;
        }

        public static List<Product> GetAllProducts()
        {
            return productList;
        }

        public static Product FindProduct(int id)
        {

            return productList.Find(product => product.Id == id);

        }


    }
}
