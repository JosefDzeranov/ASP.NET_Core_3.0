using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.DataSources;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly ProductDataSource productDataSource;

		public CartController()
		{
			productDataSource = new ProductDataSource();
		}
		public IActionResult Index()
		{
		
			return View((Cart.CartItems, Cart.Cost));	
		}

		public IActionResult Add(int productId)
		{
			var product = productDataSource.GetProductById(productId);
			CartRepository.Add(product);
			return RedirectToAction("Index");
		}
	}
}


