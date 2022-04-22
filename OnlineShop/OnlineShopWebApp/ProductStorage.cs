using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class ProductStorage: IProductStorage
    {  
        public List<Product> GetProductData()
        {
            var xDoc = XDocument.Load("Data/products.xml");
            var products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(
                                       int.Parse(p.Attribute("id").Value),
                                       p.Element("img").Value,
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value)).ToList();
            return products;
        }

        public Product TryGetProduct(int id)
        {
            var product = GetProductData().Where(p => p.Id == id)
                                                 .FirstOrDefault();
            return product;
        }
    }
}
