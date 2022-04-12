using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly ProductDataSource productDataSource;

		private readonly CartRepository cartRepository;

		public CartController(CartRepository cartRepository, ProductDataSource productDataSource)
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
			var product = productDataSource.GetProductById(productId);
			cartRepository.Add(product);
			return RedirectToAction("Index");
		}
	}
}


