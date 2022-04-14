using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class OrderBase : IOrderBase
    {
        private static List<Cart> Сarts { get; set; } = new List<Cart>();

        public void Add(Cart cart)
        {
            Сarts.Add(cart);
        }

        public Cart TryGetByUserId(string userId)
        {
            return Сarts.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
