using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProdcutBase
    {
        public static List<Product> products = new List<Product>()
        {
           new Product(1, "Незнайка на луне", 345.6m),
           new Product(2, "Что делать?", 556.50m),
           new Product(3, "Остров сокровищ", 999.0m)

        };


        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

    }
}
