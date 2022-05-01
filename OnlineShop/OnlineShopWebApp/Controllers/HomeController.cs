using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductManager _productManager;
      

        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;
          
        }
        public IActionResult Index()
        {
           
            var products = _productManager.ProductList;
           

            return View(products);
        }

        [HttpPost]
        public IActionResult SearchByName(string name)
        {
            if (name != null)
            {
                if (_productManager.ProductList.Find(x => x.Name.ToLower() == name.ToLower()) != null)
                {
                    var id = _productManager.ProductList.Find(x => x.Name.ToLower() == name.ToLower()).Id;

                    return Redirect($"/product/index/{id}");

                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }


    }
}
