using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
	public interface IProductDataSource
	{
		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int id);
	}
}