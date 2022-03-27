using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class ProdcutBase
    {
        public static List <Product> Products { get; set; }

        static ProdcutBase()
        {
            Products = new List<Product>();
            Products.Add(new Product("Id1", "Name1", "Cost1"));
            Products.Add(new Product("Id2", "Name2", "Cost2"));
            Products.Add(new Product("Id3", "Name3", "Cost3"));
           
        }

    }
}
