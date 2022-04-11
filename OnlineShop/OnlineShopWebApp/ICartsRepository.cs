using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        private static List<Cart> carts { get; set; }
        public Cart TryGetByUserId() { return carts.FirstOrDefault(); }
        public static void Add() { }
    }
}
