using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Services
{
	public class InMemoryProductDataSource : IProductDataSource
	{
		private List<Product> products = new List<Product>()
		{
			new Product("Тур в Турцию", 50000, "Тур в Турцию за 50000 рублей", "/images/turkey.jpg"),
			new Product("Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей", "/images/greece.jpg"),
			new Product("Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей", "/images/bulgary.jpg"),
			new Product("Тур на Арубу", 50000, "Тур на Арубу за 50000 рублей", "/images/aruba.jpg"),
			new Product("Тур в Мексику", 60000, "Тур в Мексику за 60000 рублей", "/images/mexico.jpg"),
			new Product("Тур на Бали", 45000, "Тур на Бали за 45000 рублей", "/images/bali.jpg"),
			new Product("Тур в Египет", 50000, "Тур в Еипет за 50000 рублей", "/images/egypt.jpg"),
			new Product("Тур в ОАЭ", 60000, "Тур в ОАЭ за 60000 рублей", "/images/uae.jpg"),
			new Product("Тур на Сейшельские острова", 45000, "Тур на Сейшельские острова за 45000 рублей", "/images/seyshels.jpg"),
			new Product("Тур на Ямайку", 50000, "Тур на Мальдивские острова за 50000 рублей", "/images/jamaica.jpg"),
			new Product("Тур в Индию", 60000, "Тур в Индию за 60000 рублей", "/images/india.jpg"),
			new Product("Тур в Таиланд", 45000, "Тур в Таиланд за 45000 рублей", "/images/thailand.jpg")
		};

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
		}

		public Product GetProductById(int id)
		{
			return products.FirstOrDefault(x => x.Id == id);
		}

		public void AddProduct(Product product)
        {
			product.Id = Product.GetNextId();

			products.Add(product);
        }

		public void RemoveProduct (int Id)
        {
			var product = products.FirstOrDefault(x => x.Id == Id);
			products.Remove(product);
        }

		public void EditProduct (Product product)
        {
			var existing = GetProductById(product.Id);
			existing.Name = product.Name;
			existing.Cost = product.Cost;
			existing.Description = product.Description;
        }
	}
}
