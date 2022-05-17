using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class ProductStorage : IProductStorage
    {
        private const string fileName = @"Data/Products.xml";
        private List<Product> _products = new List<Product>();
        public List<Product> GetProductData()
        {
             var xDoc = XDocument.Load(fileName);
            _products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(
                                       Guid.Parse(p.Attribute("id").Value),
                                       p.Element("img").Value,
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value)).ToList();
            return _products;
        }

        public Product TryGetProduct(Guid id)
        {
            var product = GetProductData().FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var products = GetProductData().Where(p => p.Name.ToLower().Contains(name.ToLower()));
            return products;
        }
        public void Add(Product product)
        {
            var xDoc = XDocument.Load(fileName);
            var root = xDoc.Element("products");
            product.Id = Guid.NewGuid();
            root.Add(new XElement("product",
                         new XAttribute("id", product.Id),
                         new XElement("img", product.ImagePath),
                         new XElement("name", product.Name),
                         new XElement("cost", product.Cost),
                         new XElement("description", product.Description)));

            xDoc.Save(fileName);
        }

        public void Edit(Product product)
        {
            var xDoc = XDocument.Load(fileName);
            var editProduct = xDoc.Element("products")
                              .Elements("product")
                              .FirstOrDefault(p => Guid.Parse(p.Attribute("id").Value) == product.Id);
            
            var imagePath = editProduct.Element("img");
            imagePath.Value = product.ImagePath;
            
            var name = editProduct.Element("name");
            name.Value = product.Name;

            var cost = editProduct.Element("cost");
            cost.Value = product.Cost.ToString();

            var desc = editProduct.Element("description");
            desc.Value = product.Description;

            xDoc.Save(fileName);
        }

        public void Remove(Guid id)
        {
            var xDoc = XDocument.Load(fileName);
            var root = xDoc.Element("products");

            var product = root.Elements("product")
                              .FirstOrDefault(p => Guid.Parse(p.Attribute("id").Value) == id);

                product.Remove();
                xDoc.Save(fileName);
        }
    }
}
