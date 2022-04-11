using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
	public interface ICartRepository
	{
		Dictionary<Product, int> CartItems { get; set; }
		decimal Cost { get; }

		void Add(Product product);
	}
}