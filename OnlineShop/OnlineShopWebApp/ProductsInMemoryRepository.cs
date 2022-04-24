using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryRepository : IProductBase
    {
        public IEnumerable<Product> AllProducts()
        {
            var xDoc = XDocument.Load("Models/products.xml");
            var products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(
                                       int.Parse(p.Element("id").Value),
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value));
            return products;
        }

    }
}
