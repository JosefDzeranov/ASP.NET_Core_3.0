using Microsoft.AspNetCore.Mvc;

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
            return productCatalog.GetProduct(id);
        }
        public string Save(string name)
        {
            
            return productCatalog.WriteToJson(name);
        }

    }
}
