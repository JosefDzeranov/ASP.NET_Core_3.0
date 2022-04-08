using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class DataStorage
    {
        private static List<Basket> products = new List<Basket>();

        public IEnumerable<Basket> Products
        {
            get
            {
                return products;
            }
        }

        public void AddToBasket(Product product, int quantity)
        {
            Basket productInBasket = products.Where(p => p.Product.Id == product.Id)
                                                      .FirstOrDefault();
            if (productInBasket == null)
            {
                products.Add(new Basket(product, 1));
            }
            else
            {
                productInBasket.Quantity += quantity;
            }
        }

        public decimal GetTotalSum()
        {
            return products.Sum(p => p.Product.Cost * p.Quantity);
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
