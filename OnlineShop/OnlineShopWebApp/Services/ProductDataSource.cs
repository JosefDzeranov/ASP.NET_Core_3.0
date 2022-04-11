using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Services
{
	public class ProductDataSource
	{
		private List<Product> products = new List<Product>()
		{
			new Product("Тур в Турцию", 50000, "Тур в Турцию за 50000 рублей", "/images/turkey.jpg"),
			new Product("Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей", "/images/greece.jpg"),
			new Product("Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей", "/images/bulgary.jpg")
		};

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
		}

		public Product GetProductById(int id)
		{
			return products.FirstOrDefault(x => x.Id == id);
		}
	}
}
