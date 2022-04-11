using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

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
			var product = productDataSource.GetProductById(productId);
			cartRepository.Add(product);
			return RedirectToAction("Index");
		}
	}
}


