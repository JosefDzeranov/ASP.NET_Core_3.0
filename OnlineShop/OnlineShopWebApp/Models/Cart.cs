using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShopWebApp.DataSources;
using System;
using System.Linq;

namespace OnlineShopWebApp.Models
{
	public class Cart
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public List<CartItem> Items { get; set; }

		public decimal Cost
		{
			get
			{
				return Items.Sum(x => x.Cost);
			}
		}


	}
}
