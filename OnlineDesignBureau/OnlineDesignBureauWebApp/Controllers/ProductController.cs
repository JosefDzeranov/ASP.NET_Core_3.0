using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public ProductController()
        {
            productCatalog = new ProductCatalog();
        }
        public string Index(int id)
        {
            var product = Convert.ToString(ProductCatalog.products[id]);
            return product;
        }
        public string Save(string name)
        {
            
            return productCatalog.WriteToJson(name);
        }
    }
}
