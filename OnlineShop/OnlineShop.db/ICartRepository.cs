using OnlineShop.db.Models;
using System.Collections.Generic;
using System; 

namespace OnlineShop.db

{
	public interface ICartRepository
	{
		//Dictionary<Product, int> CartItems { get; set; }

		//decimal Cost { get; }

		void Add(int id, string userId);

		void Remove(int id, string userId);

		void Add(Product product, string userId);

		void Remove(Product product, string userId);

		void RemoveAll(string userId);

		Cart TryGetByUserId(string userId);

		void GetAllProduct();
	}
}