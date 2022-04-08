using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class DataStorage
    {
        private static List<Basket> productBaskets = new List<Basket>();

        public IEnumerable<Basket> ProductBaskets
        {
            get
            {
                return productBaskets;
            }
        }

        public void AddProductBasket(Product product)
        {
            var productBasket = productBaskets.Where(p => p.Product.Id == product.Id)
                                                           .FirstOrDefault();
            if (productBasket == null)
            {
                productBaskets.Add(new Basket(product));
            }
            else
            {
                productBasket.Quantity++;
            }
        }

        public decimal GetTotalSum()
        {
            return productBaskets.Sum(b => b.Product.Cost * b.Quantity);
        }

        public IEnumerable<Product> GetProductDataFromXML()
        {
            var xDoc = XDocument.Load("Data/products.xml");
            var products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(
                                       int.Parse(p.Attribute("id").Value),
                                       p.Element("img").Value,
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value));
            return products;
        }

        public Product TryGetProduct(int id)
        {
            var product = new DataStorage().GetProductDataFromXML()
                                           .Where(p => p.Id == id)
                                           .FirstOrDefault();
            return product;
        }
    }
}
