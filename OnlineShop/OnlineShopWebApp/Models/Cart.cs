using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
	public static class Cart
	{
		public static Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

		public static decimal Cost
		{
			get
			{
				return CartItems.Sum(item => item.Key.Cost * item.Value);
			}
		}
	}
}
