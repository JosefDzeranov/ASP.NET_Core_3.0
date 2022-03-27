using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class ProdcutBase
    {
        public static List <Product> Products { get; set; }

        static ProdcutBase()
        {
            Products = new List<Product>();
            Products.Add(new Product(1, "1", 1));
            Products.Add(new Product(2, "2", 2));
            Products.Add(new Product(3, "3", 3));
           
        }

    }
}
