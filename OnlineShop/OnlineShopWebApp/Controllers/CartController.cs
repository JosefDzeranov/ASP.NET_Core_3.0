using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View(Cart.addedProducts);
        }

        public IActionResult AddToCart(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);
            
               


                if (Cart.addedProducts.Contains(foundProduct))
                {

                    foreach (var product in Cart.addedProducts)
                    {
                        if (product == foundProduct)
                        {
                            product.Number++;
                            product.TotalCost += product.Cost;

                        }
                    }

                }
                else
                {
                    foundProduct.Number++;
                    Cart.addedProducts.Add(foundProduct);
                }

            



            return View("Index", Cart.addedProducts);
        }

    }

   
}
