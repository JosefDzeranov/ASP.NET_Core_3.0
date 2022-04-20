using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
	public interface ICartRepository
	{
		Dictionary<Product, int> CartItems { get; set; }

		decimal Cost { get; }

		void Add(int id);

		void Remove(int id);

		void Add(Product product);

		void Remove(Product product);

		void RemoveAll();

		int Amount { get; }
	}
}