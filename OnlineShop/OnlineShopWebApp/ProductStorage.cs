using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class ProductStorage : IProductStorage
    {
        private List<Product> _products = new List<Product>();
        public List<Product> GetProductData()
        {
            var xDoc = XDocument.Load("Data/AllProducts.xml");
            _products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(  
                                       p.Attribute("id").Value,
                                       p.Element("img").Value,
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value)).ToList();
            return _products;
        }

        public Product TryGetProduct(string id)
        {
            var product = GetProductData().Where(p => p.Id == id)
                                                 .FirstOrDefault();
            return product;
        }

        public void AddProduct(Product product)
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

        public void EditProduct(Product product)
        {
            var xDoc = XDocument.Load("Data/AllProducts.xml");
            var editProduct = xDoc.Element("products")
                              .Elements("product")
                              .FirstOrDefault(p => p.Attribute("id").Value == product.Id);
            
            var imagePath = editProduct.Element("img");
            imagePath.Value = product.ImagePath;
            
            var name = editProduct.Element("name");
            name.Value = product.Name;

            var cost = editProduct.Element("cost");
            cost.Value = product.Cost.ToString();

            var desc = editProduct.Element("description");
            desc.Value = product.Description;

            xDoc.Save("Data/AllProducts.xml");
        }

        public void RemoveProduct(string id)
        {
            var xDoc = XDocument.Load("Data/AllProducts.xml");
            var root = xDoc.Element("products");

            var product = root.Elements("product")
                              .FirstOrDefault(p => p.Attribute("id").Value == id);

                product.Remove();
                xDoc.Save("Data/AllProducts.xml");
        }
    }
}
