using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.DataSources
{
    public class ProductDataSource
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Тур в Турцию", 50000, "Тур в Турцию за 50000 рублей"),
            new Product("Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей"),
            new Product("Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей")
        };

        public IEnumerable<Product> GetAllProducts ()
        {
            return products;
        }

        public Product GetProductById (int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}
