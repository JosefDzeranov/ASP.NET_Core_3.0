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
        public string ReadFile()
        {
            productCatalog.ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in productCatalog.GetProducts())
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
