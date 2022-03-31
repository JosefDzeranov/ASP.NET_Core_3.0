using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class Data
    {
        public IEnumerable<Product> GetDataFromXML()
        {
            var xDoc = XDocument.Load("Models/products.xml");
            var products = xDoc.Element("products")
                               .Elements("product")
                               .Select(p => new Product(
                                       int.Parse(p.Attribute("id").Value),
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value),
                                       p.Element("description").Value));
            return products;
        }
    }
}
