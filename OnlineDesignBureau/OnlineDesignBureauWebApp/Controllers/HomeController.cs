using Microsoft.AspNetCore.Mvc;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog _productCatalog;
        public HomeController()
        {
            _productCatalog = new ProductCatalog();
        }
        public string Index()
        {
            if (_productCatalog.GetProducts().Count==0)
                _productCatalog.ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in _productCatalog.GetProducts())
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
