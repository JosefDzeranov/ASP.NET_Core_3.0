using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class ProductStorage : IProductStorage
    {
        //private List<Product> _products = new List<Product>();
        public List<Product> GetProductData()
        {
            var xDoc = XDocument.Load("Data/AllProducts.xml");
            var products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(  
                                       p.Attribute("id").Value,
                                       p.Element("img").Value,
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value)).ToList();
            return products;
        }

        public Product TryGetProduct(string productId)
        {
            var product = GetProductData().Where(p => p.Id == productId)
                                                 .FirstOrDefault();
            return product;
        }

        public void AddProductToXml(Product product)
        {
            var xDoc = XDocument.Load("Data/AllProducts.xml");
            var root = xDoc.Element("products");

            root.Add(new XElement("product",
                         new XAttribute("id", product.GuidId),
                         new XElement("img", product.ImagePath),
                         new XElement("name", product.Name),
                         new XElement("cost", product.Cost),
                         new XElement("description", product.Description)));

            xDoc.Save("Data/AllProducts.xml");
        }

        public void EditProduct(string productId)
        {

        }
        public void RemoveProduct(string productId)
        {

        }
    }
}
