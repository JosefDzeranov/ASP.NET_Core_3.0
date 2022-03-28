using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class ProdcutBase
    {
        public static List <Product> Products { get; set; }

        static ProdcutBase()
        {
            Products = new List<Product>();
            Products.Add(new Product(1, "Незнайка на луне", 345.6m));
            Products.Add(new Product(2, "Что делать?", 556.50m));
            Products.Add(new Product(3, "Остров сокровищ", 999.0m));
           
        }

    }
}
