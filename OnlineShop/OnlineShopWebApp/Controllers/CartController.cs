using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.DataSources;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
			var cart = CartRepository.TryGetByUserId(Constans.UserId);
			return View(cart);	
		}

		public IActionResult Add(int productId)
		{
			var product = productDataSource.GetProductById(productId);
			CartRepository.Add(product, Constans.UserId);
			return RedirectToAction("Index");
		}
	}
}


