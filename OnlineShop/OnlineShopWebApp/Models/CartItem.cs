using System;
namespace OnlineShopWebApp.Models
{
	public class CartItem
	{
		public Guid Id { get; set; }
		public Product Product { get; set; }

		public int Amount { get; set; }

		public decimal Cost
		{
			get
			{
				return Product.Cost * Amount; 
			}
		}

	}
}
