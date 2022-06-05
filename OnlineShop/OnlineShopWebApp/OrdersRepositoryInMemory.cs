using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class OrdersRepositoryInMemory
    {
        private List<CartViewModel> orders = new List<CartViewModel>();

        public void AddCart(CartViewModel cart)
        {
            orders.Add(cart);
        }
    }
}
