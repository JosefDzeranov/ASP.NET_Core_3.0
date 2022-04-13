using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductDataSource productDataSource;

		private readonly ICartRepository cartRepository;

		public CartController(ICartRepository cartRepository, IProductDataSource productDataSource)
		{
			this.cartRepository = cartRepository;
			this.productDataSource = productDataSource;
		}
		public IActionResult Index()
		{
		
			return View((cartRepository.CartItems, cartRepository.Cost));	
		}

		public IActionResult Add(int productId)
		{
			cartRepository.Add(productId);
			return RedirectToAction("Index");
		}

        public IActionResult RemoveProduct(int productId)
        {
            cartRepository.Remove(productId);
            return RedirectToAction("Index");
        }
      
		public IActionResult RemoveAll()
        {
			cartRepository.RemoveAll();
			return RedirectToAction("Index");
        }
    }
}


